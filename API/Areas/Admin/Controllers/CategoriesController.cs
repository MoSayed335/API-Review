using Microsoft.AspNetCore.Mvc;
using API.Utility;
using API.DataAccess;
using Microsoft.EntityFrameworkCore;
using API.Models;
using System.Linq;
namespace API.Areas.Admin.Controllers
{
    [Area(SD.Admin_Area)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(string name , int Page =1)
        {
            var category = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            
                category = category.Where(c => c.Name != null && c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            
            if(Page < 0) 
                Page = 1;

            int CarantPage = Page;

            double totalPages = Math.Ceiling(CarantPage / (double)5); //5

            category = _context.Categories
             .Skip(Page - 1)
             .Take((int)totalPages);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _context.Categories.ToListAsync();
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
