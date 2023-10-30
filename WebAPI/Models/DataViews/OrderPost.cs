using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DataViews
{
    public class OrderPost
    {
        [Required]
        public string OrderCode { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
