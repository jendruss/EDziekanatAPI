using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EDziekanat.Application.DeansOffices.Dto;
using EDziekanat.Application.DeansOffices.Vm;

namespace EDziekanat.Application.DeansOffices
{
    public interface IReservationService
    {
        public Task CreateSchedules(CancellationToken cancellationToken);
        public Task<List<int>> GetReservationsAvailableDaysForCurrentMonth(Guid deansOfficeId);
        public Task<List<string>> GetReservationsAvailableHoursForChoosenDay(Guid deansOfficeId, DateTime date);
        public void CreateReservationsSchedule(ReservationCreateScheduleDto scheduleModel);
    }
}
