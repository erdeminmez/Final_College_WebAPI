using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Models.Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Professor> Professors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(" connection string goes here");
            optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        }

    }
}