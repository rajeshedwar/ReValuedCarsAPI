using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReValuedCarsAPI.Models
{
    public class Cars : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get; set; }
        public string Name { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int FuelTypeID { get; set; }
        public int OwnerTypeID { get; set; }
        public int RegistrationTypeID { get; set; }
        public int InsuranceTypeID { get; set; }
        public int KilometersDriven { get; set; }
        public int Price { get; set; }
        public string RegistrationNumber { get; set; }
        public int StateID { get; set; }
        public int CityID { get; set; }
        public int PinCode { get; set; }
    }
}
