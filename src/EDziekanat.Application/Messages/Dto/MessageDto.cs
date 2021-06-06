using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Application.Messages.Dto
{
    public class MessageDto
    {
        public string UserId { get; set; }
        public string DeansOfficeId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
