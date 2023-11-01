using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DataViews
{
    public class ProductPost
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ProducentId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
