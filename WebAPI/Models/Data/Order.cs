using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models.Data
{
    [Index(nameof(OrderCode), IsUnique = true)]
    public class Order
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }

        [Required]
        public string OrderCode { get; set; }

        [Required]
        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public string CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
