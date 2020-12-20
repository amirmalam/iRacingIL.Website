using iRacingIL.Website.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRacingIL.Website.Data
{

    public class iRacingILContext : DbContext
    {
        public iRacingILContext(DbContextOptions<iRacingILContext> options) : base(options)
        {
        }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Driver> Enrollments { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Track> Tracks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>().ToTable("Incidents");
            modelBuilder.Entity<Driver>().ToTable("Drivers");
            modelBuilder.Entity<Race>().ToTable("Races");
            modelBuilder.Entity<Season>().ToTable("Seasons");
            modelBuilder.Entity<Track>().ToTable("Tracks");
        }
    }
}

