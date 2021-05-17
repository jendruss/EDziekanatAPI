using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using ILogger = Castle.Core.Logging.ILogger;

namespace EDziekanat.Application.DeansOffices
{
    public class ReservationService : IReservationService
    {
        private readonly ILogger<ReservationService> _logger;
        public ReservationService(ILogger<ReservationService> logger)
        {
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
    }
}
