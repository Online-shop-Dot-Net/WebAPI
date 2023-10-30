using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DataViews
{
    public class ProducentPost
    {
        [Required]
        public string ProducentName { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
