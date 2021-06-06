using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using EDziekanat.Application.Messages.Dto;
using EDziekanat.Application.Messages.Vm;
using EDziekanat.Core.Messages;
using EDziekanat.EntityFramework;

namespace EDziekanat.Application.Messages
{
    public class MessageService : IMessageService
    {
        private readonly EDziekanatDbContext _context;
        private readonly IMapper _mapper;
        public MessageService(EDziekanatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void AddMessage(MessageDto messageDto)
        {
            Message msg = new Message()
            {
                FirstName = messageDto.FirstName,
                LastName = messageDto.LastName,
                Text = messageDto.Text,
                SendDate = DateTime.Now,
                UserId = messageDto.UserId,
                DeansOfficeId = messageDto.DeansOfficeId
            };

            _context.Messages.Add(msg);
            _context.SaveChanges();
        }

        public List<MessageVm> GetAllMessagesForThisConversation(Guid userId, Guid deansOfficeId)
        {
            var messages = _context.Messages
                .Where(m => m.UserId==userId && m.DeansOfficeId == deansOfficeId)
                .OrderBy(m => m.SendDate)
                .ToList();
            return _mapper.Map<List<Message>, List<MessageVm>>(messages);
        }


    }
}
