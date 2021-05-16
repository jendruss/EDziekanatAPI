using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using EDziekanat.Application.Dto;
using EDziekanat.Application.Dto.Account;
using EDziekanat.Application.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EDziekanat.Core.Permissions;
using EDziekanat.Core.Roles;
using EDziekanat.Core.Users;
using EDziekanat.Web.Core.Authentication;
using EDziekanat.Web.Core.Controllers;

namespace EDziekanat.Web.Api.Controller.Account
{
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtTokenConfiguration _jwtTokenConfiguration;
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        readonly ILogger<AccountController> _logger;
        private readonly IUserAppService _userAppService;


        public AccountController(
            UserManager<User> userManager,
            IOptions<JwtTokenConfiguration> jwtTokenConfiguration,
            IConfiguration configuration,
            SmtpClient smtpClient,
            ILogger<AccountController> logger,
            IUserAppService userAppService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _smtpClient = smtpClient;
            _logger = logger;
            _userAppService = userAppService;
            _jwtTokenConfiguration = jwtTokenConfiguration.Value;
        }

        [HttpPost("/api/[action]")]
        public async Task<ActionResult<LoginOutput>> Login([FromBody]LoginInput input)
        {
            var userToVerify = await CreateClaimsIdentityAsync(input.UserNameOrEmail, input.Password);
            if (userToVerify == null)
            {
                return BadRequest(new List<NameValueDto>
                {
                    new NameValueDto("UserNameOrPasswordIncorrect", "The user name or password is incorrect!")
                });
            }

            Guid.TryParse(userToVerify.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value, out var userId);

            var user = await _userAppService.GetUserForCreateOrUpdateAsync(userId);

            var token = new JwtSecurityToken
            (
                issuer: _jwtTokenConfiguration.Issuer,
                audience: _jwtTokenConfiguration.Audience,
                claims: userToVerify.Claims,
                expires: _jwtTokenConfiguration.EndDate,
                notBefore: _jwtTokenConfiguration.StartDate,
                signingCredentials: _jwtTokenConfiguration.SigningCredentials
            );

            return Ok(new LoginOutput
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                User = user
            });
        }

        [HttpPost("/api/[action]")]
        public async Task<ActionResult> Register([FromBody]RegisterInput input)
        {
            var user = await _userManager.FindByEmailAsync(input.Email);
            if (user != null)
            {
                return BadRequest(new List<NameValueDto>
                {
                    new NameValueDto("EmailAlreadyExist", "This email already exists!")
                });
            }

            var applicationUser = new User
            {
                UserName = input.Login,
                Email = input.Email,
                EmailConfirmed = true,
                FirstName = input.FirstName,
                LastName = input.LastName,
                DeansOfficeId = input.DeansOfficeId
            };

            var result = await _userManager.CreateAsync(applicationUser, input.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(e => new NameValueDto(e.Code, e.Description)).ToList());
            }
            else
            {
                _userAppService.GrantRolesToUser(new List<Guid> { DefaultRoles.Student.Id }, applicationUser);
            }

            return Ok();
        }

        [HttpPost("/api/[action]")]
        [Authorize(Policy = DefaultPermissions.PermissionNameForMemberAccess)]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordInput input)
        {
            if (input.NewPassword != input.PasswordRepeat)
            {
                return BadRequest(new List<NameValueDto>
                {
                    new NameValueDto("PasswordsDoesNotMatch", "Passwords doesn't match!")
                });
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(user, input.CurrentPassword, input.NewPassword);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(e => new NameValueDto(e.Code, e.Description)).ToList());
            }

            return Ok();
        }

        [HttpPost("/api/[action]")]
        public async Task<ActionResult<ForgotPasswordOutput>> ForgotPassword([FromBody] ForgotPasswordInput input)
        {
            var user = await FindUserByUserNameOrEmail(input.UserNameOrEmail);
            if (user == null)
            {
                return NotFound(new List<NameValueDto>
                {
                    new NameValueDto("UserNotFound", "User is not found!")
                });
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = _configuration["App:ClientUrl"] + "/account/reset-password?token=" + resetToken;
            var message = new MailMessage(
                @from: _configuration["Email:Smtp:Username"],
                to: user.Email,
                subject: "Reset your password",
                body: $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>"
            );
            message.IsBodyHtml = true;
#if !DEBUG
            await _smtpClient.SendMailAsync(message);
#endif
            _logger.LogInformation(Environment.NewLine + Environment.NewLine +
                                   "******************* Reset Password Link *******************" +
                                   Environment.NewLine + Environment.NewLine +
                                   callbackUrl +
                                   Environment.NewLine + Environment.NewLine +
                                   "***********************************************************" +
                                   Environment.NewLine);
            return Ok(new ForgotPasswordOutput { ResetToken = resetToken });
        }

        [HttpPost("/api/[action]")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordInput input)
        {
            var user = await FindUserByUserNameOrEmail(input.UserNameOrEmail);
            if (user == null)
            {
                return NotFound(new List<NameValueDto>
                {
                    new NameValueDto("UserNotFound", "User is not found!")
                });
            }

            var result = await _userManager.ResetPasswordAsync(user, input.Token, input.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors.Select(e => new NameValueDto(e.Code, e.Description)).ToList());
            }

            return Ok();
        }

        private async Task<ClaimsIdentity> CreateClaimsIdentityAsync(string userNameOrEmail, string password)
        {
            if (string.IsNullOrEmpty(userNameOrEmail) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var userToVerify = await FindUserByUserNameOrEmail(userNameOrEmail);

            if (userToVerify == null)
            {
                return null;
            }

            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return new ClaimsIdentity(new GenericIdentity(userNameOrEmail, "Token"), new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userNameOrEmail),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userToVerify.Id.ToString())
                });
            }

            return null;
        }

        private async Task<User> FindUserByUserNameOrEmail(string userNameOrEmail)
        {
            return await _userManager.FindByNameAsync(userNameOrEmail) ??
                   await _userManager.FindByEmailAsync(userNameOrEmail);
        }
    }
}