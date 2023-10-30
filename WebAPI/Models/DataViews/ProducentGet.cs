using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DataViews
{
    public class ProducentGet
    {
        [Required]
        public int ProducentId { get; set; }

        [Required]
        public string ProducentName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
