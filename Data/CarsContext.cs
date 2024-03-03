using CarApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication.Data
{
    public class CarsContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cars> Cars { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-31I93P6\SQLEXPRESS;Database=CarDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }
    }
}
