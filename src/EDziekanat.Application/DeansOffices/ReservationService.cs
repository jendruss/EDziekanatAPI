using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Castle.Core.Logging;
using EDziekanat.Application.DeansOffices.Dto;
using EDziekanat.Application.DeansOffices.Vm;
using EDziekanat.Core.DeansOffices;
using EDziekanat.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ILogger = Castle.Core.Logging.ILogger;

namespace EDziekanat.Application.DeansOffices
{
    public class ReservationService : IReservationService
    {
        private readonly EDziekanatDbContext _context;
        private readonly IMapper _mapper;   
        private readonly ILogger<ReservationService> _logger;

        public ReservationService(EDziekanatDbContext context, IMapper mapper, ILogger<ReservationService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task CreateSchedules(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation($"Creating schedules for DeansOffices - Background HostedService executed.");
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        public async Task<List<int>> GetReservationsAvailableDaysForCurrentMonth(Guid deansOfficeId)
        {
            var now = DateTime.Now;

            var daysOfMonth = await _context.Reservations
                .Where(r =>
                    r.DeansOfficeId == deansOfficeId &&
                    r.StudentId == null &&
                    r.Date > now &&
                    r.Date.Year == now.Year &&
                    r.Date.Month == now.Month)
                .Select(r => r.Date.Day)
                .Distinct()
                .ToListAsync();

            return daysOfMonth;
        }

        public async Task<List<string>> GetReservationsAvailableHoursForChoosenDay(Guid deansOfficeId, DateTime date)
        {
            var now = DateTime.Now;
            var hours = await _context.Reservations
                .Where(r=>
                    r.DeansOfficeId == deansOfficeId &&
                    r.Date.Date == date.Date &&
                    r.Date > now &&
                    r.StudentId == null)
                .Select(r=>r.Date.ToString("HH:mm")) // Godziny dla danego dziekanatu maja się nie powtarzać - zabezpieczone podczas dodawania
                .ToListAsync();

            return hours;
        }

        public void CreateReservationsSchedule(ReservationCreateScheduleDto scheduleModel)
        {
            scheduleModel.FromDate = scheduleModel.FromDate.Date;
            scheduleModel.ToDate = scheduleModel.ToDate.Date;

            var deansOffice = _context.DeansOffices.FirstOrDefault(d=>d.Id==scheduleModel.DeansOfficeId);
            if (deansOffice==null)
            {
                throw new Exception("Wrong DeansOfficeId or doesn't exist.");
            }

            if (scheduleModel.ToDate < scheduleModel.FromDate || scheduleModel.ToHour < scheduleModel.FromHour)
            {
                throw new Exception("Dates and hours 'To' has to be greater than 'From'");
            }

            var now = DateTime.Now;

            if (scheduleModel.FromDate < now || scheduleModel.ToDate < now)
            {
                throw new Exception("Dates 'To' and 'From' has to be greater than DateTime.Now");
            }

            var schedule = new List<Reservation>();
            while (scheduleModel.FromDate <= scheduleModel.ToDate)
            {
                for (int h = scheduleModel.FromHour; h < scheduleModel.ToHour; h++)
                {
                    for (int m = 0; m < 60; m += 15)
                    {
                        var reservationDate = scheduleModel.FromDate.AddHours(h).AddMinutes(m);

                        // Sprawdzenie czy istnieje juz rezerwacji o takim samym DeansOfficeId i Date 
                        var exist = _context.Reservations.Any(r => r.DeansOfficeId == scheduleModel.DeansOfficeId && r.Date == reservationDate); 
                        if (!exist)
                        {
                            if (scheduleModel.IncludeWeekends)
                            {
                                schedule.Add(new Reservation
                                {
                                    Date = reservationDate,
                                    DeansOffice = deansOffice,
                                    DeansOfficeId = scheduleModel.DeansOfficeId,
                                    Id = new Guid(),
                                    OperationName = string.Empty,
                                    StudentId = null
                                });
                            }
                            else
                            {
                                if (reservationDate.DayOfWeek != DayOfWeek.Saturday &&
                                    reservationDate.DayOfWeek != DayOfWeek.Sunday)
                                {
                                    schedule.Add(new Reservation
                                    {
                                        Date = reservationDate,
                                        DeansOffice = deansOffice,
                                        DeansOfficeId = scheduleModel.DeansOfficeId,
                                        Id = new Guid(),
                                        OperationName = string.Empty,
                                        StudentId = null
                                    });
                                }
                            }
                        }
                    }
                }
                scheduleModel.FromDate = scheduleModel.FromDate.AddDays(1);
            }

            _context.Reservations.AddRange(schedule);
            _context.SaveChanges();
        }

        public async Task<ReservationVm> GetReservationByIdAsync(Guid reservationId)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == reservationId);
            return _mapper.Map<Reservation,ReservationVm>(reservation);
        }

        public async Task<ReservationVm> ReserveAsync(ReservationDto reservationDto)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.DeansOfficeId == reservationDto.DeansOfficeId && r.Date == reservationDto.Date );

            if (reservation == null)
            {
                throw new Exception("Reservation with given Date and DeansOfficeId not found.");
            }

            if (reservation.StudentId != null)
            {
                throw new Exception("This date is already reserved.");
            }

            var now = DateTime.Now;
            if (reservation.Date < now)
            {
                throw new Exception("Cannot reserve old slots.");
            }

            reservation.StudentId = reservationDto.StudentId;
            reservation.OperationName = reservationDto.OperationName;

            await _context.SaveChangesAsync();
            return _mapper.Map<Reservation, ReservationVm>(reservation);
        }

        public async Task<ReservationVm> CancelReservationAsync(Guid reservationId)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.Id == reservationId);

            if (reservation != null)
            {
                if (reservation.StudentId == null)
                {
                    throw new Exception("There is no student assigned to this reservation.");
                }
                reservation.StudentId = null;
                reservation.OperationName = string.Empty;
                await _context.SaveChangesAsync();
            }

            return _mapper.Map<Reservation, ReservationVm>(reservation);
        }

        public async Task<IEnumerable<ReservationVm>> GetAllCurrentReservationsForStudent(Guid studentId)
        {
            var now = DateTime.Now;
            var reservations = await _context.Reservations.Where(r=>r.StudentId==studentId && r.Date>=now).ToListAsync(); // Założenie w projekcie, że student jest przypisany do jednego dziekanatu.

            return _mapper.Map<List<Reservation>, List<ReservationVm>>(reservations);
        }

        
        public async Task<IEnumerable<string>> GetAvailableOperationsByDeansOfficeId(Guid deansOfficeId)
        {
            return await _context.Operations.Where(o => o.DeansOfficeId == deansOfficeId).OrderBy(o => o.Name).Select(o => o.Name).ToListAsync();
        }

        public async Task<IEnumerable<ReservationVm>> GetReservationsByDeansOfficeId(Guid deansOfficeId)
        {
            var today = DateTime.Now.Date;
            var reservations = await _context.Reservations.Where(r => r.DeansOfficeId == deansOfficeId && r.Date.Date >= today && r.StudentId!=null).Include(s=>s.Student).ToListAsync();
            return _mapper.Map<List<Reservation>, List<ReservationVm>>(reservations);
        }
    }
}
