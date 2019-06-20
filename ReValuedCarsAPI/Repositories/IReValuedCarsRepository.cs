using ReValuedCarsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReValuedCarsAPI.Repositories
{
    public interface IReValuedCarsRepository
    {
        IEnumerable<Make> GetMake();
        IEnumerable<Model> GetModel(int id);
        IEnumerable<FuelType> GetFuelType();
        IEnumerable<OwnerType> GetOwnerType();
        IEnumerable<RegistrationType> GetRegistrationType();
        IEnumerable<InsuranceType> GetInsuranceType();
        IEnumerable<CarDetails> GetCars();
        CarDetails GetCar(int id);
        Task<Cars> AddCarAsync(Cars item);
        Task<Cars> UpdateCarAsync(Cars item);
        Task<Cars> DeleteCarAsync(int id);
        IEnumerable<CarImages> GetCarImages(int id);
        Task<CarImages> AddCarImageAsync(CarImages item);
        Task<ViewedCars> AddViewedCarAsync(ViewedCars item);
    }
}
