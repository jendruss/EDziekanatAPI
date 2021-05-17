using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Application.DeansOffices.Dto
{
    public class ReservationsAvailableHoursDto
    {
        public Guid DeansOfficeId { get; set; }
        public DateTime Date { get; set; }
    }
}
