using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleworkerservice
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly UserEqualizerService _userService;
        private readonly IServiceCollection _ser;
        private string resultMessage;
        private readonly IServiceProvider scopeFactory;
        public Worker(ILogger<Worker> logger, IServiceCollection ser,IServiceProvider ScopeFactory,UserEqualizerService userService)
        {
            _logger = logger;
            _userService = userService;
            scopeFactory = ScopeFactory;
            _ser = ser;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                using (var scope = scopeFactory.CreateScope())
                {
                    var userservice = scope.ServiceProvider.GetRequiredService<UserEqualizerService>();

                    _logger.LogInformation("Starting service...");


                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    var result = userservice.ExecuteService();

                    if (result != null)
                    {
                        resultMessage = "Successfully processed";
                    }
                    else
                    {
                        resultMessage = "Processed with failure";
                    }
                    _logger.LogInformation(resultMessage);

                    _logger.LogInformation("Stoping service...");

                    await Task.Delay(30000, stoppingToken);
                }
            }
        }

    }
}
