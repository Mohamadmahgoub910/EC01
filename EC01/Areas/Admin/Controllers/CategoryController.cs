using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EC01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ApplicationDBContext _context = new ApplicationDBContext();
        public IActionResult Index()
        {
            var categories = _context.Categories.AsNoTracking().AsQueryable();
            return View(categories.AsEnumerable());
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Edit 
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category is null)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }
            return View(category);
        }

        //[HttpPost]
        //public IActionResult Edit(Category category)
        //{
        //    _context.Categories.Add(category);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
    }
    
}
