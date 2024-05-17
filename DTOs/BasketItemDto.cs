﻿using System.ComponentModel.DataAnnotations;

namespace BisWork.DTOs
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string TemplateName { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price Must Be Grater Than Zero")]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quentity Must Be At least One !")]
        public int Quentity { get; set; }
    }
}
