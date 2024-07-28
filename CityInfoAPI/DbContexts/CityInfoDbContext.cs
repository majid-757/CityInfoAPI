using CityInfoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CityInfoAPI.DbContexts
{
    public class CityInfoDbContext : DbContext
    {

        public CityInfoDbContext(DbContextOptions<CityInfoDbContext> options) : base(options)
        {

        }

        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointOfInterest { get; set; } = null!;


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite();
        //    base.OnConfiguring(optionsBuilder);
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("Tabriz")
                {
                    Id = 1,
                    Description = "This is tabriz"
                },
                new City("Tehran")
                {
                    Id = 2,
                    Description = "This is Tehran"
                },
                new City("Shiraz")
                {
                    Id = 3,
                    Description = "This is Shiraz"
                });


            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("Eynali")
                {
                    Id = 1,
                    CityId = 1,
                    Description = "Eynali in tabriz"
                },
                new PointOfInterest("milad tower")
                {
                    Id = 2,
                    CityId = 2,
                    Description = "milad tower in tehran"
                },
                new PointOfInterest("hafez")
                {
                    Id = 3,
                    CityId = 3,
                    Description = "hafez in shiraz"
                }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
