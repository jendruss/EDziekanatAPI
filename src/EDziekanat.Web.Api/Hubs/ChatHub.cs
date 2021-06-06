using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using EDziekanat.Application.Messages;
using EDziekanat.Application.Messages.Dto;
using EDziekanat.Core.Messages;
using EDziekanat.EntityFramework;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

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
            List<Message> msgs = _messageService.GetAllMessagesForThisUser(messageDto.UserId);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            JsonDocument jsonResult = JsonDocument.Parse(JsonSerializer.Serialize(msgs, options));

            _context.Users.Include(r=>r.UserRoles).FirstOrDefault(u=>u.DeansOfficeId==messageDto.DeansOfficeId && u.)

            //user - znalezc pracownika dla danego dziekanatu 
            await Clients.User(user).SendAsync("ReceiveMessage", jsonResult);
        }
    }
}
