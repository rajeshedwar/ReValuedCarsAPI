using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReValuedCarsAPI.Intrastructures;
using ReValuedCarsAPI.Models;

namespace ReValuedCarsAPI.Repositories
{
    public class ReValuedCarsRepository : IReValuedCarsRepository
    {
        private ReValuedCarsDbContext db;
        private DbSet<Make> dsMake;
        private DbSet<Model> dsModel;
        private DbSet<FuelType> dsFuelType;
        private DbSet<OwnerType> dsOwnerType;
        private DbSet<RegistrationType> dsRegistrationType;
        private DbSet<InsuranceType> dsInsuranceType;
        private DbSet<Cars> dsCars;
        private DbSet<CarImages> dsCarImage;
        private DbSet<ViewedCars> dsViewedCar;

        public ReValuedCarsRepository(ReValuedCarsDbContext dbContext)
        {
            this.db = dbContext;
            this.dsMake = db.Set<Make>();
            this.dsModel = db.Set<Model>();
            this.dsFuelType = db.Set<FuelType>();
            this.dsOwnerType = db.Set<OwnerType>();
            this.dsRegistrationType = db.Set<RegistrationType>();
            this.dsInsuranceType = db.Set<InsuranceType>();
            this.dsCars = db.Set<Cars>();
            this.dsCarImage = db.Set<CarImages>();
            this.dsViewedCar = db.Set<ViewedCars>();
        }

        public IEnumerable<FuelType> GetFuelType()
        {
            return dsFuelType.ToList();
        }

        public IEnumerable<Make> GetMake()
        {
            return dsMake.ToList();
        }

        public IEnumerable<Model> GetModel(int id)
        {
            return dsModel.Where(m => m.MakeID == id).ToList();
        }

        public IEnumerable<OwnerType> GetOwnerType()
        {
            return dsOwnerType.ToList();
        }

        public IEnumerable<RegistrationType> GetRegistrationType()
        {
            return dsRegistrationType.ToList();
        }

        public IEnumerable<InsuranceType> GetInsuranceType()
        {
            return dsInsuranceType.ToList();
        }

        public IEnumerable<CarDetails> GetCars()
        {
            //return dsCars.ToList();
            var car = from c in dsCars
                      join m in dsMake on c.MakeID equals m.Id
                      join md in dsModel on c.ModelID equals md.Id
                      join f in dsFuelType on c.FuelTypeID equals f.Id
                      join o in dsOwnerType on c.FuelTypeID equals o.Id
                      join r in dsRegistrationType on c.FuelTypeID equals r.Id
                      join i in dsInsuranceType on c.FuelTypeID equals i.Id
                      join u in dsCarImage on c.Id equals u.CarID
                      select new CarDetails
                      {
                          Id = c.Id,
                          Name = c.Name,
                          MakeYear = c.MakeYear,
                          Make = m.Name,
                          Model = md.Name,
                          CC = md.CC,
                          FuelType = f.Name,
                          OwnerType = o.Name,
                          RegistrationType = r.Name,
                          InsuranceType = i.Name,
                          KilometersDriven = c.KilometersDriven,
                          Price = c.Price,
                          RegistrationNumber = c.RegistrationNumber,
                          ImageUrl = u.Url
                      };
            return car.ToList<CarDetails>();
        }

        public CarDetails GetCar(int id)
        {
            //return dsCars.Find(id);            

            var car = from c in dsCars
                      join m in dsMake on c.MakeID equals m.Id
                      join md in dsModel on c.ModelID equals md.Id
                      join f in dsFuelType on c.FuelTypeID equals f.Id
                      join o in dsOwnerType on c.FuelTypeID equals o.Id
                      join r in dsRegistrationType on c.FuelTypeID equals r.Id
                      join i in dsInsuranceType on c.FuelTypeID equals i.Id
                      join u in dsCarImage on c.Id equals u.CarID
                      where c.Id == id
                      select new CarDetails
                      {
                          Id = c.Id,
                          Name = c.Name,
                          MakeYear = c.MakeYear,
                          Make = m.Name,
                          Model = md.Name,
                          CC = md.CC,
                          FuelType = f.Name,
                          OwnerType = o.Name,
                          RegistrationType = r.Name,
                          InsuranceType = i.Name,
                          KilometersDriven = c.KilometersDriven,
                          Price = c.Price,
                          RegistrationNumber = c.RegistrationNumber,
                          ImageUrl = u.Url
                      };
            return car.SingleOrDefault();
        }

        public async Task<Cars> AddCarAsync(Cars item)
        {
            await dsCars.AddAsync(item);
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<Cars> UpdateCarAsync(Cars item)
        {
            dsCars.Update(item).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<Cars> DeleteCarAsync(int id)
        {
            var item = await dsCars.FindAsync(id);
            if (item == null)
            {
                throw new Exception("Car details not found for detetion");
            }
            dsCars.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }

        public IEnumerable<CarImages> GetCarImages(int id)
        {
            return dsCarImage.Where(m => m.CarID == id).ToList();
        }

        public async Task<CarImages> AddCarImageAsync(CarImages item)
        {
            await dsCarImage.AddAsync(item);
            await db.SaveChangesAsync();
            return item;
        }

        public async Task<ViewedCars> AddViewedCarAsync(ViewedCars item)
        {
            await dsViewedCar.AddAsync(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
