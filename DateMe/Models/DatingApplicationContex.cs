using Microsoft.EntityFrameworkCore;

namespace DateMe.Models
{
    public class DatingApplicationContex : DbContext //Liaison from the app to the database
    {
        public DatingApplicationContex(DbContextOptions<DatingApplicationContex> options) : base (options) // constructor
        { 
        }

        public DbSet<Application> Applications { get; set; }

        public DbSet<Major> Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // seed data
        {
            modelBuilder.Entity<Major>().HasData(
                new Major { MajorId = 1, MajorName="Information Systems" },
                new Major { MajorId = 2, MajorName = "Computer Science" },
                new Major { MajorId = 3, MajorName = "Biology" },
                new Major { MajorId = 4, MajorName = "Nursing" },
                new Major { MajorId = 5, MajorName = "Business Administration" }
            );
        }
    }
}
