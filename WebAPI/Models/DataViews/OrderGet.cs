using EllipticCurve.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DataViews
{
    public class OrderGet
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string OrderCode { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
