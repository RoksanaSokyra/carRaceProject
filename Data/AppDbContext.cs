using Microsoft.EntityFrameworkCore;
using RaceSimulator.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaceSimulator.Data
{// czy klasa kontekstu to czy inny folder i czy co z nazwa
    //czy dbcontext z konsruktuorem z argumentem DbContextOptions czy override OnConfiguring
    class AppDbContext : DbContext
    {
       // public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        //tak zeby bylo z appsettings i dbcontext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RaceDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
