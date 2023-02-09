using FakeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeApi.Data
{
    public class ContactosContext: DbContext
    {
        public ContactosContext()
        {

        }

        public ContactosContext(DbContextOptions<ContactosContext> options)
            : base(options)
        {
        }

        public DbSet<Contactos> Contactos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

                string sqlstring = builder.GetSection("ConnectionStrings:db").Value;
                optionsBuilder.UseSqlServer(sqlstring);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}