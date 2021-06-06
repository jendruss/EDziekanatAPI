using EDziekanat.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EDziekanat.Application.Messages.Dto;
using EDziekanat.Application.Messages.Vm;

namespace EDziekanat.Application.Messages
{
    public interface IMessageService
    {
        public void AddMessage(MessageDto messageDto);
        public List<MessageVm> GetAllMessagesForThisConversation(Guid studentId, Guid deansOfficeId);

        
    }
}
