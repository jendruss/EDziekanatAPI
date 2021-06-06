using System;
using System.Collections.Generic;
using System.Text;

namespace EDziekanat.Application.DeansOffices.Vm
{
    public class ReservationVm
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }

        public string OperationName { get; set; }

        public Guid DeansOfficeId { get; set; }

        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
