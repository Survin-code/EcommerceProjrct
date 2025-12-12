using EncryptSolution;
namespace ProductApi.Models
{
    public class Product
    {
        public int Id { get; set; }
       [EncryptField]
        public string Name { get; set; }
        [EncryptField]
        public string Category { get; set; }
        public int Price { get; set; }
        public int StockQuantity { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
