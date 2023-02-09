using evaluacionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace evaluacionAPI.Data
{
    public class LibraryContext: DbContext
    {
        public LibraryContext()
        {

        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Books> Books {get; set;}

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