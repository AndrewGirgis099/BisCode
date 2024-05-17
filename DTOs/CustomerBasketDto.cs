using BisWork.Core.Entities.Basket;
using System.ComponentModel.DataAnnotations;

namespace BisWork.DTOs
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
