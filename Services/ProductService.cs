using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Dto;
using ProductApi.Models;

namespace ProductApi.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Product>> GetProductAsync() =>

            await _dbContext.product.Include(p => p.User).ToListAsync();

        public async Task<Product> GetProductById(int id) =>

        await _dbContext.product.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddProductAsync(addProductDto addDto)
        {
            var result = new Product
            {
                UserId = addDto.UserId,
                Name = addDto.Name,
                Category = addDto.Category,
                Price = addDto.Price,
                StockQuantity = addDto.StockQuantity
            };
            _dbContext.product.Add(result);
            await _dbContext.SaveChangesAsync();
           
        }
        public async Task<bool> UpdateProductAsync(int id, updateProductDto updateDto)
        {
            var result =await _dbContext.product.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            result.UserId = updateDto.UserId;
            result.Name = updateDto.Name;
            result.Category = updateDto.Category;
            result.Price = updateDto.Price;
            result.StockQuantity = updateDto.StockQuantity;
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var result = await _dbContext.product.FindAsync(id);
            if (result == null) return false;

             _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
            return true;  
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            _dbContext.product.Add(new Product { Name = "Abc", Category = "qwerty" });
            await _dbContext.SaveChangesAsync();

            return null;
        }
       
        }
    }

