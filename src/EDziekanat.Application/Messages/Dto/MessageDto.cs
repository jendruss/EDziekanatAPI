using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Application.Messages.Dto
{
    public class MessageDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; } // Kto wysyła wiadomość
        public Guid DeansOfficeId { get; set; }
        public string Text { get; set; }
        public Guid StudentId { get; set; } // Z kim jest konwersacja
    }
}
