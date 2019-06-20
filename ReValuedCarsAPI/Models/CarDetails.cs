using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReValuedCarsAPI.Models
{
    public class CarDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }
        public string OwnerType { get; set; }
        public string RegistrationType { get; set; }
        public string InsuranceType { get; set; }
        public int KilometersDriven { get; set; }
        public int Price { get; set; }
        public string RegistrationNumber { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int PinCode { get; set; }
        public string ImageUrl { get; set; }
    }
}
