using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EDziekanat.Application.DeansOffices.Dto;
using EDziekanat.Application.DeansOffices.Vm;
using EDziekanat.Core.DeansOffices;

namespace EDziekanat.Application.DeansOffices
{
    public interface IReservationService
    {
        public Task CreateSchedules(CancellationToken cancellationToken);
        public Task<List<int>> GetReservationsAvailableDaysForCurrentMonth(Guid deansOfficeId);
        public Task<List<string>> GetReservationsAvailableHoursForChoosenDay(Guid deansOfficeId, DateTime date);
        public void CreateReservationsSchedule(ReservationCreateScheduleDto scheduleModel);
        public Task<ReservationVm> GetReservationByIdAsync(Guid id);
        public Task<ReservationVm> ReserveAsync(ReservationDto reservationDto);
        public Task<ReservationVm> CancelReservationAsync(Guid id);
        public Task<IEnumerable<ReservationVm>> GetAllCurrentReservationsForStudent(Guid studentId);
        public Task<IEnumerable<ReservationVm>> GetReservationsForCurrentDayByDeansOfficeId(Guid deansOfficeId);
    }
}
