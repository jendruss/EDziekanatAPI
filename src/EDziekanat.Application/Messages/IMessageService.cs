using EDziekanat.Core.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EDziekanat.Application.Messages.Dto;

namespace EDziekanat.Application.Messages
{
    public interface IMessageService
    {
        public Task AddMessage(MessageDto messageDto);
        public Task<List<Message>> GetAllChannelMessages(object channelId);
    }
}
