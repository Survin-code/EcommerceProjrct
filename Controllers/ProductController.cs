using Microsoft.AspNetCore.Mvc;
using ProductApi.Dto;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService) 
        {
        _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetProductAsync();
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _productService.GetProductById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]addProductDto addDto)
        {
            var result = _productService.AddProductAsync(addDto);
            return Ok(new { Message = " Product added" });
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateProduct(int id,updateProductDto updateDto)
        {
           var result =await  _productService.UpdateProductAsync(id, updateDto);
            if (result == null) return NotFound();
            return Ok(new { Message = "product updated successfully" });
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
          var result = await _productService.DeleteProductAsync(id);
            if(result ==null) return NotFound();
            return Ok(result);
        }

    }
}
