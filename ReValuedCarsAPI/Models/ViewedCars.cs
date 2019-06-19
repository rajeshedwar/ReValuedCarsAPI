using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReValuedCarsAPI.Models
{
    public class ViewedCars : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get; set; }
        public string Message { get; set; }
        public int UserID { get; set; }
        public int CarID { get; set; }
        public int QuotePrice { get; set; }
    }
}
