using System;
using System.Collections.Generic;
using System.Text;
using EDziekanat.Core.DeansOffices;
using EDziekanat.Core.Users;

namespace EDziekanat.Core.Messages
{
    public class Message : BaseEntity
    {
        //todo: Czat mial zawierac załaczniki np pliki/zdjecia itp. - dodac property odpowiedzielane za przechowywanie plików
        public string Text { get; set; }

        public Guid StudentId { get; set; }
        public virtual User User { get; set; }

        public Guid DeansOfficeId { get; set; }
        public virtual DeansOffice DeansOffice { get; set; }
    }
}
