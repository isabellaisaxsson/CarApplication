using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarApplication.Models
{
    public class OrderDetail
    {
        [ForeignKey("Car")]
        public Customer PersonId { get; set; }

        [Key]
        public Cars CarId { get; set; }
    }
}