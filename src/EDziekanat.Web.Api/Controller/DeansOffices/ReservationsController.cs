using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDziekanat.Application.DeansOffices;
using EDziekanat.Application.DeansOffices.Dto;
using EDziekanat.Application.DeansOffices.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EDziekanat.Core.DeansOffices;
using EDziekanat.EntityFramework;
using EDziekanat.Web.Core.Controllers;

namespace EDziekanat.Web.Api.Controller.DeansOffices
{
    [Route("api/[controller]/[action]")]
    public class ReservationsController : BaseController
    {
        private readonly EDziekanatDbContext _context;
        private readonly IReservationService _reservationService;

        public ReservationsController(EDziekanatDbContext context, IReservationService reservationService)
        {
            _context = context;
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<int>>> GetReservationsAvailableDaysForCurrentMonth(Guid deansOfficeId)
        {
            return await _reservationService.GetReservationsAvailableDaysForCurrentMonth(deansOfficeId);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetReservationsAvailableHoursForChoosenDay(Guid deansOfficeId, DateTime date)
        {
            return await _reservationService.GetReservationsAvailableHoursForChoosenDay(deansOfficeId,date);
        }

        [HttpPost]
        public void CreateReservationsSchedule(ReservationCreateScheduleDto scheduleModel)
        {
            _reservationService.CreateReservationsSchedule(scheduleModel);
        }
    }
}
