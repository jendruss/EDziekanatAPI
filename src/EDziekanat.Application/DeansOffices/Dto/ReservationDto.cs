using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Application.DeansOffices.Dto
{
    public class ReservationDto
    {
        public DateTime Date { get; set; }

        public string OperationName { get; set; }

        public Guid DeansOfficeId { get; set; }

        public Guid StudentId { get; set; }
    }
}
