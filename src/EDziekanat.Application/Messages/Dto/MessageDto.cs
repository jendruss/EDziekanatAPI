﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Application.Messages.Dto
{
    public class MessageDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid UserId { get; set; }
        public Guid DeansOfficeId { get; set; }
        public string Text { get; set; }
    }
}
