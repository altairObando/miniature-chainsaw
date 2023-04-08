using DAL.Catalogs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    /// <summary>
    ///     Core database context
    /// </summary>
    public class Context: IdentityDbContext<Security.User>
    {
        public string ConnectionString { get; set; }

        public Context( string connection) { 
            ConnectionString = connection;
        }
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Contacts.Contact> Contact { get; set; }
        public DbSet<Contacts.Address> Address { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}