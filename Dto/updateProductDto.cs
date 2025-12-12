using ProductApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Dto
{
    public class updateProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [Required]
        public int UserId { get; set; }
       
    }
}
