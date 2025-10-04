using System.Diagnostics;
using EC01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EC01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // باخد اوبجكت من الابلكيشن دي بي كونتكست عشان هستخدمه ف اكتر من اكسن بكتبه فوق كده مش مع الاكشن
        private ApplicationDBContext _context = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = _context.Products/*.AsNoTracking()*/.Include(e=>e.Category).AsQueryable();
            // Add Filter 
            return View(products.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
