using Microsoft.EntityFrameworkCore;
using ReValuedCarsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReValuedCarsAPI.Intrastructures
{
    public class ReValuedCarsDbContext : DbContext
    {
        public ReValuedCarsDbContext(DbContextOptions<ReValuedCarsDbContext> options) : base(options)
        {
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<OwnerType> OwnerTypes { get; set; }
        public DbSet<RegistrationType> RegistrationTypes { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<Cars> Cars { get; set; }
        public DbSet<CarImages> CarImages { get; set; }
        public DbSet<ViewedCars> ViewedCars { get; set; }
    }
}
