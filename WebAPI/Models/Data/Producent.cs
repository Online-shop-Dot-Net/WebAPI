using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace WebAPI.Models.Data
{
    public class Producent
    {

        private ILazyLoader LazyLoader { get; set; }

        private ICollection<Order> _products;
        public ICollection<Order> products
        {
            get => LazyLoader.Load(this, ref _products);
            set => _products = value;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ProducentId { get; set; }

        [Required]
        public string ProducentName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
