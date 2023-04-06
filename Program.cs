using sampleworkerservice;
using sampleworkerservice.Models;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<UserDbContext>();
        services.AddDbContext<UserDbContext>();

        services.AddScoped<IUserService, UserEqualizerService>();
        services.AddHostedService<UserEqualizerService>();
            
        
    })
    .Build();

await host.RunAsync();
