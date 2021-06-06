using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Application.Messages.Vm
{
    public class MessageVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public Guid UserId { get; set; }
        public Guid DeansOfficeId { get; set; }
        public Guid StudentId { get; set; }
    }
}
