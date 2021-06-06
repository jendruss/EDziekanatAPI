using System;
using System.Collections.Generic;
using System.Text;
using EDziekanat.EntityFramework;

namespace EDziekanat.Application.Messages
{
    public class MessageService : IMessageService
    {
        private readonly EDziekanatDbContext _context;
        public MessageService(EDziekanatDbContext context)
        {
            _context = context;
        }


    }
}
