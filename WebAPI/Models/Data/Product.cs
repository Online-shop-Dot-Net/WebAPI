using EllipticCurve.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebAPI.Models.Data
{
    public class Product
    {
        private ILazyLoader LazyLoader { get; set; }

        private ICollection<Order> _orders;
        public ICollection<Order> orders
        {
            get => LazyLoader.Load(this, ref _orders);
            set => _orders = value;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ProducentId { get; set; }

    }
}
