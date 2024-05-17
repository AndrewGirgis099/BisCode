using BisWork.Core.Entities;

namespace BisWork.DTOs
{
    public class TemplateToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal price { get; set; }
        public string PictureUrl { get; set; }
        public string TemplateUrl { get; set; }
        public string TemplateDescription { get; set; }
        public string Category { get; set; }
    }
}
