using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Application.DeansOffices.Dto
{
    public class ReservationCreateScheduleDto
    {
        public Guid DeansOfficeId { get; set; }
        public int FromHour { get; set; } 
        public int ToHour { get; set; } 
        public DateTime FromDate { get; set; } 
        public DateTime ToDate { get; set; } 
        public bool IncludeWeekends { get; set; }
    }
}
