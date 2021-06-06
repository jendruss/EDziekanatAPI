using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using EDziekanat.Application.Messages.Dto;
using EDziekanat.Application.Messages.Vm;
using EDziekanat.Application.Users.Vm;
using EDziekanat.Core.Messages;
using EDziekanat.Core.Users;
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
                StudentId = messageDto.StudentId,
                DeansOfficeId = messageDto.DeansOfficeId
            };

            _context.Messages.Add(msg);
            _context.SaveChanges();
        }

        public List<MessageVm> GetAllMessagesForThisConversation(Guid studentId, Guid deansOfficeId)
        {
            var messages = _context.Messages
                .Where(m => m.StudentId==studentId && m.DeansOfficeId == deansOfficeId)
                .OrderBy(m => m.SendDate)
                .ToList();
            return _mapper.Map<List<Message>, List<MessageVm>>(messages);
        }

        
        public List<UserVm> GetStudentsWhichHaveConversation(Guid deansOfficeId)
        {
            var studentsIds = _context.Messages.Where(m => m.DeansOfficeId == deansOfficeId).Select(i=>i.StudentId).ToList().Distinct();

            var students = new List<UserVm>();

            foreach (var id in studentsIds)
            {
                var student = _context.Users.FirstOrDefault(u => u.Id == id);
                students.Add(_mapper.Map<User, UserVm>(student));
            }

            return students;
        }
    }
}
