using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleworkerservice.Models
{
    public class UserDbContext : DbContext,IServiceProvider
    {
        //private   IServiceProvider serpro;
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options)
        {  }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EurofinsSample;Trusted_Connection=True;");

        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Geo> Geo { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}
