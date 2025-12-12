using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> add([FromForm] User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Data Added" });
        }
        [HttpGet]
        public async Task<IActionResult> get()
        {
           var result =await _context.user.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            var result = await _context.user.FindAsync(id);
            return Ok(result);
        } 
        
    }
}
