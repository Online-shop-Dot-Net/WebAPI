using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DataViews
{
    public class ProductGet
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ProducentId { get; set; }

        public string ProducentName { get; set; }
    }
}
