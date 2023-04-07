using Microsoft.EntityFrameworkCore;
using sampleworkerservice.Models;

namespace sampleworkerservice
{
    public class UserEqualizerService:IHostedService,IUserService,IServiceProvider
    {
        private readonly ILogger<UserEqualizerService> _logger;
       // private readonly PlaceHolderClient _client;
        private readonly UserDbContext _context;
        private IServiceProvider _sp;
           

        public UserEqualizerService(ILogger<UserEqualizerService> logger, IServiceProvider sp)
        {
            
            _logger = logger;
            // _client = client;
            _sp = sp;
           // _context = context;
           _context=sp.CreateScope().ServiceProvider.GetRequiredService<UserDbContext>();
        }

        public List<User> ExecuteService()
        {
          //  using (var scope = _sp.CreateScope())
            //{
               // var ct = scope.ServiceProvider.GetRequiredService<UserDbContext>();


                _logger.LogInformation("Starting process");

                var result = _context.Users.ToList();

                //var result = await EqualizeUsers(placeHolderUsers);

                _logger.LogInformation("Ending process");

                return result;

            //}
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            
            _logger.LogInformation("Ending process");
            return Task.CompletedTask;
            

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {

            _logger.LogInformation("Ending process");
            return null;

        }
        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }



        //public virtual async Task<bool> EqualizeUsers(List<User> phUsers)
        //{
        //    var users = _context.Users.ToList();

        //    var newUsers = phUsers.Where(x => !users.Any(x1 => x1.Username != x.Username && x1.Email != x.Email)).ToList();

        //    if (!newUsers.Any())
        //    {
        //        _logger.LogInformation("No new users to add");
        //        return true;
        //    }

        //    _logger.LogInformation($"Found {newUsers.Count} new users");

        //    return await SaveNewUsers(newUsers);
        //}

        //public virtual async Task<bool> SaveNewUsers(List<PlaceHolderUser> newUsers)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Saving new users");

        //        var newUsersEntity = newUsers.Select(x => new User
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            Username = x.Username,
        //            Email = x.Email,
        //            Address = new Models.Address
        //            {
        //                Id = x.Id,
        //                City = x.Address?.City,
        //                Geo = new Models.Geo { Id = x.Id, Lat = x.Address?.Geo?.Lat, Lng = x.Address?.Geo?.Lng },
        //                Street = x.Address?.Street,
        //                Suite = x.Address?.Suite,
        //                Zipcode = x.Address?.Zipcode,
        //            },
        //            Phone = x.Phone,
        //            Website = x.Website,
        //            Company = new Models.Company { Id = x.Id, Name = x.Company?.Name, CatchPhrase = x.Company?.CatchPhrase, Bs = x.Company?.Bs }
        //        }).ToList();

        //        await _context.Users.AddRangeAsync(newUsersEntity);
        //        await _context.Address.AddRangeAsync(newUsersEntity.Select(x => x.Address).ToList());
        //        await _context.Geo.AddRangeAsync(newUsersEntity.Select(x => x.Address.Geo).ToList());
        //        await _context.Company.AddRangeAsync(newUsersEntity.Select(x => x.Company).ToList());
        //        await _context.SaveChangesAsync();

        //        _logger.LogInformation("New users successfully saved");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error saving new users - {ex.Message}");
        //        return false;
        //    }
        //}
    }

       
    }