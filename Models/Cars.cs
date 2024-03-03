using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication.Models
{
    public class Cars
    {
        [Key]
        public int carId { get; set; }

        [ForeignKey("Car")]
        public int personId { get; set; }
        public string registrationNr {  get; set; }
        public string make { get; set; }
        public string model {  get; set; }
        public int year { get; set; }
        public int price { get; set; }
       
    }
}
