﻿using Microsoft.EntityFrameworkCore;

namespace DateMe.Models
{
    public class DatingApplicationContex : DbContext
    {
        public DatingApplicationContex(DbContextOptions<DatingApplicationContex> options) : base (options) // constructor
        { 
        }

        public DbSet<Application> Applications { get; set; }
    }
}
