using System.ComponentModel.DataAnnotations;

namespace BisWork.DTOs
{
    public class OrderDto
    {
        [Required]
        public string BasketId { get; set; }
    }
}
