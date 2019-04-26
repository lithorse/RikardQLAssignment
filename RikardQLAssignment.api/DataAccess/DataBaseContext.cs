using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RikardQLAssignment.api.Models;

namespace RikardQLAssignment.api.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var SeedPositions = new List<Position>()
            {
                new Position()
                {
                    Id = "0",
                    Latitude = "41.7325",
                    Longitude = "49.9469"
                },
                new Position()
                {
                    Id = "1",
                    Latitude = "36.4511",
                    Longitude = "28.2278"
                },
                new Position()
                {
                    Id = "2",
                    Latitude = "44.244167",
                    Longitude = "7.769444"
                },
                new Position()
                {
                    Id = "3",
                    Latitude = "59.3293",
                    Longitude = "18.0686"
                },
                new Position()
                {
                    Id = "4",
                    Latitude = "59.9139",
                    Longitude = "10.7522"
                }
            };

            modelBuilder.Entity<Position>().HasData(SeedPositions);
        }

        public DbSet<Position> Positions { get; set; }
    }
}
