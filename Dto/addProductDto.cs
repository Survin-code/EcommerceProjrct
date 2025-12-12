using ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto
{
    public class addProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
