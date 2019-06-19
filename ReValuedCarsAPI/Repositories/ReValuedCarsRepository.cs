using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReValuedCarsAPI.Intrastructures;
using ReValuedCarsAPI.Models;

namespace ReValuedCarsAPI.Repositories
{
    //public class ReValuedCarsRepository<T> : IReValuedCarsRepository<T> where T : BaseEntity
    //{
    //    private ReValuedCarsDbContext db;
    //    private DbSet<T> ds;

    //    public ReValuedCarsRepository(ReValuedCarsDbContext dbContext)
    //    {
    //        this.db = dbContext;
    //        this.ds = db.Set<T>();
    //    }

    //    public async Task<T> AddAsync(T item)
    //    {
    //        await ds.AddAsync(item);
    //        await db.SaveChangesAsync();
    //        return item;
    //    }

    //    public async Task<T> DeleteAsync(int id)
    //    {
    //        var item = await ds.FindAsync(id);
    //        if (item == null)
    //        {
    //            throw new Exception("Item not found for detetion");
    //        }
    //        ds.Remove(item);
    //        await db.SaveChangesAsync();
    //        return item;
    //    }

    //    public T Get(int id)
    //    {
    //        var item = ds.Find(id);
    //        return item;
    //    }

    //    public IEnumerable<T> GetAll()
    //    {
    //        return ds.ToList();
    //    }

    //    public async Task<T> UpdateAsync(int id, T item)
    //    {
    //        ds.Update(item).State = EntityState.Modified;
    //        await db.SaveChangesAsync();
    //        return item;
    //    }
    //}

    public class ReValuedCarsRepository : IReValuedCarsRepository
    {
        private ReValuedCarsDbContext db;
        private DbSet<Make> dsMake;
        private DbSet<Model> dsModel;
        private DbSet<FuelType> dsFuelType;
        private DbSet<OwnerType> dsOwnerType;
        private DbSet<RegistrationType> dsRegistrationType;
        private DbSet<InsuranceType> dsInsuranceType;

        public ReValuedCarsRepository(ReValuedCarsDbContext dbContext)
        {
            this.db = dbContext;
            this.dsMake = db.Set<Make>();
            this.dsModel = db.Set<Model>();
            this.dsFuelType = db.Set<FuelType>();
            this.dsOwnerType = db.Set<OwnerType>();
            this.dsRegistrationType = db.Set<RegistrationType>();
            this.dsInsuranceType = db.Set<InsuranceType>();
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
    }
}
