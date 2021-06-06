using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EDziekanat.Application.Messages;
using EDziekanat.Application.Messages.Dto;
using EDziekanat.Application.Messages.Vm;
using EDziekanat.Core.Messages;
using EDziekanat.EntityFramework;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EDziekanat.Web.Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IMessageService _messageService;
        private readonly EDziekanatDbContext _context;

        public ChatHub(EDziekanatDbContext context, IMessageService messageService)
        {
            _context = context;
            _messageService = messageService;
        }

        public async Task SendPrivateMessage(MessageDto messageDto)
        {
            _messageService.AddMessage(messageDto);

            List<MessageVm> msgs = _messageService.GetAllMessagesForThisConversation(messageDto.UserId,messageDto.DeansOfficeId);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            JsonDocument jsonResult = JsonDocument.Parse(JsonSerializer.Serialize(msgs, options));

            var employeeRoleId = _context.Roles.FirstOrDefault(r => r.NormalizedName == "EMPLOYEE").Id;

            if (employeeRoleId == Guid.Empty)
            {
                employeeRoleId = Guid.Parse("11D14A89-3A93-4D39-A94F-82B823F0D4CE");
            }

            var destinationUserId = _context.Users.Include(r => r.UserRoles)
                .Where(u => u.DeansOfficeId == messageDto.DeansOfficeId &&
                            u.UserRoles.Any(ur => ur.RoleId == employeeRoleId)).Select(u=>u.Id).ToString();

            await Clients.User(destinationUserId).SendAsync("ReceiveMessage", jsonResult);
        }
    }
}
