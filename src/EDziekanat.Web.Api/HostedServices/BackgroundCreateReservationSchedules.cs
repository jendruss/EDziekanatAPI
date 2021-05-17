using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EDziekanat.Application.DeansOffices;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EDziekanat.Web.Api.HostedServices
{
    public class BackgroundCreateReservationSchedules : BackgroundService
    {
        private readonly IReservationService _reservationService;

        public BackgroundCreateReservationSchedules(ILogger<BackgroundCreateReservationSchedules> logger, IReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _reservationService.CreateSchedules(stoppingToken);
        }
    }
}
