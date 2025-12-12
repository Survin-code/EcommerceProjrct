using ProductApi.Dto;
using ProductApi.Models;

namespace ProductApi.Services
{
    public interface IProductService 
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetProductById(int id);
        Task AddProductAsync(addProductDto addDto);
        Task<bool> UpdateProductAsync(int id, updateProductDto updateDto);
        Task<bool> DeleteProductAsync(int id);
    }
}
