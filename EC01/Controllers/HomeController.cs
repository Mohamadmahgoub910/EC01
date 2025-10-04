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

        public IActionResult Index(FilterProductVM filterProductVM)
        {
            const decimal discount = 50;
            var products = _context.Products/*.AsNoTracking()*/.Include(e=>e.Category).AsQueryable();
            // Add Filter 
            if (filterProductVM.name is not null)
            {
                products = products.Where(e => e.Name.Contains(filterProductVM.name));
                ViewBag.name = filterProductVM.name;
            }

            if (filterProductVM.minPrice is not null)
            {
                products = products.Where(e => e.Price - e.Price * e.Discount / 100 > filterProductVM.minPrice);
                ViewBag.minPrice = filterProductVM.minPrice;
            }

            if (filterProductVM.maxPrice is not null)
            {
                products = products.Where(e => e.Price - e.Price * e.Discount / 100 < filterProductVM.maxPrice);
                ViewBag.maxPrice = filterProductVM.maxPrice;
            }

            if (filterProductVM.categoryId is not null)
            {
                products = products.Where(e => e.CategoryId == filterProductVM.categoryId);
                ViewBag.categoryId = filterProductVM.categoryId;
            }

            if (filterProductVM.brandId is not null)
            {
                products = products.Where(e => e.BrandId == filterProductVM.brandId);
                ViewBag.brandId = filterProductVM.brandId;
            }

            if (filterProductVM.isHot)
            {
                products = products.Where(e => e.Discount > discount);
                ViewBag.isHot = filterProductVM.isHot;
            }

            // Categories
            var categories = _context.Categories;
            //ViewData["categories"] = categories.AsEnumerable();
            ViewBag.categories = categories.AsEnumerable();

            // Brands
            var brands = _context.Brands;
            ViewData["brands"] = brands.AsEnumerable();



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
