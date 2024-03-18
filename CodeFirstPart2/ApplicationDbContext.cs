using CodeFirstPart2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstPart2
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }

        public ApplicationDbContext() {}

        public ApplicationDbContext(DbContextOptions options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=IKNEZEVIC-INT;Database=Car;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;User=sa;Password=14092001;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Car>().HasData(
        //        new Car { Id = 1, Brand = "Audi", Model = "A6", Color = "Black", Year = 2020, Chassis = 123, Number = 5 },
        //        new Car { Id = 2, Brand = "BMW", Model = "520", Color = "Blue", Year = 2020, Chassis = 321, Number = 6 },
        //        new Car { Id = 3, Brand = "Mercedes", Model = "E220", Color = "White", Year = 2020, Chassis = 231, Number = 7 }
        //    );
        //}
    }
}
