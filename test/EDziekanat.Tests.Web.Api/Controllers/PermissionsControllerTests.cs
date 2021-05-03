using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using EDziekanat.Application.Permissions.Dto;
using EDziekanat.Core.Users;
using EDziekanat.EntityFramework;
using Xunit;

namespace EDziekanat.Tests.Web.Api.Controllers
{
    public class PermissionsControllerTests : ApiTestBase
    {
        private readonly string _token;

        public PermissionsControllerTests()
        {
            _token = LoginAsAdminUserAndGetTokenAsync().Result;
        }

        [Fact]
        public async Task Should_Get_Granted_Permissions()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/permissions?userNameOrEmail=" + DefaultUsers.TestAdmin.UserName);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var response = await TestServer.CreateClient().SendAsync(requestMessage);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var permissions = await response.Content.ReadAsAsync<IEnumerable<PermissionDto>>();
            Assert.True(permissions.Any());
        }
    }
}
