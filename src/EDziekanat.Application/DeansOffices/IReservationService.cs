using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EDziekanat.Application.DeansOffices
{
    public interface IReservationService
    {
        public Task CreateSchedules(CancellationToken cancellationToken);
    }
}
