using Microsoft.EntityFrameworkCore;

namespace DAL
{
    /// <summary>
    ///     Core database context
    /// </summary>
    public class Context: DbContext
    {
        public string ConnectionString { get; set; }

        public Context( string connection) { 
            ConnectionString = connection;
        }
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Contacts.Contact> Contact { get; set; }
        public DbSet<Contacts.Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}