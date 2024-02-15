using Microsoft.EntityFrameworkCore;

namespace DateMe.Models
{
    public class DatingApplicationContex : DbContext //Liaison from the app to the database
    {
        public DatingApplicationContex(DbContextOptions<DatingApplicationContex> options) : base (options) // constructor
        { 
        }

        public DbSet<Application> Applications { get; set; }
    }
}
