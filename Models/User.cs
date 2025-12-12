using EncryptSolution;
namespace ProductApi.Models
{
    public class User
    {
        public int Id { get; set; }
        [EncryptField]
        public string UserName { get; set; }
        [EncryptField]
        public string Password { get; set; }
        public string Role { get; set; }

       //public ICollection<Product> Products { get; set; }
    }

    
}
