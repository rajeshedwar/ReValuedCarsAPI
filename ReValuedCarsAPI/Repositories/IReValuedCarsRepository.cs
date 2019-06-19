using ReValuedCarsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReValuedCarsAPI.Repositories
{
    //public interface IReValuedCarsRepository<T> where T : BaseEntity
    //{
    //    IEnumerable<T> GetAll();

    //    T Get(int id);

    //    Task<T> AddAsync(T item);

    //    Task<T> UpdateAsync(int id, T item);

    //    Task<T> DeleteAsync(int id);
    //}

    public interface IReValuedCarsRepository
    {
        IEnumerable<Make> GetMake();
        IEnumerable<Model> GetModel(int id);
        IEnumerable<FuelType> GetFuelType();
        IEnumerable<OwnerType> GetOwnerType();
        IEnumerable<RegistrationType> GetRegistrationType();
        IEnumerable<InsuranceType> GetInsuranceType();
    }
}
