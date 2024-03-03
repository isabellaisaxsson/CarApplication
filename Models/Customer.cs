using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication.Models
{
    public class Customer
    {

        [Key]
        public int PersonId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime birthDate {  get; set; }
        public byte hasLicence { get; set;}

       
    }
}
