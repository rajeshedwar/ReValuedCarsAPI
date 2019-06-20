using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReValuedCarsAPI.Models
{
    public class Model : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get; set; }
        public string Name { get; set; }
        public int MakeID { get; set; }
        public string Length { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string SeatingCapacity { get; set; }
        public string Displacement { get; set; }
        public string FuelType { get; set; }
        public string MaxPower { get; set; }
        public string Mileage { get; set; }
        public string TransmissionType { get; set; }
        public string NoofGears { get; set; }
        public string AirConditioner { get; set; }
        public string PowerWindows { get; set; }
        public string CentralLocking { get; set; }
        public string ABS { get; set; }
        public string Airbags { get; set; }
        public string CC { get; set; }
    }
}
