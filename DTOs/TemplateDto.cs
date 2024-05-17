using System.ComponentModel.DataAnnotations;

namespace BisWork.DTOs
{
    public class TemplateDto
    {

        public string Name { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal price { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string TemplateUrl { get; set; }
        [Required]
        public string TemplateDescription { get; set; }
        [Required]
        public int CategoryId { get; set; }

    }
}
