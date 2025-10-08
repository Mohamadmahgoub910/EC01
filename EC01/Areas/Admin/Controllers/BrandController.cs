using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EC01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        ApplicationDBContext _context = new ApplicationDBContext();
        public IActionResult Index()
        {
            var brands = _context.Brands.AsNoTracking().AsQueryable();

            return View(brands.Select(e => new
            {
                e.Id,
                e.Name,
                e.Description,
                e.Status
            }).AsEnumerable());
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand, IFormFile img)
        {
            if(img is not null && img.Length > 0)
            {
                // save img in wwwroot
                var fileName = Guid.NewGuid().ToString()+Path.GetExtension(img.FileName);// sdfgfds-sdfbg-fdgg-gxf
                //var filePath = Directory.GetCurrentDirectory() + "./././" + fileName;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    img.CopyTo(stream);
                }
                // Save img to db 
                brand.Img = fileName;
            }
            // save brand in db 
            _context.Brands.Add(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // Edit 
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var brand = _context.Brands.FirstOrDefault(c => c.Id == id);
            if (brand is null)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }
            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            _context.Brands.Update(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ////Delete
        //public IActionResult Delete(int id)
        //{
        //    var brand = _context.Brands.FirstOrDefault(c => c.Id == id);
        //    if (brand is null)
        //    {
        //        return RedirectToAction("NotFoundPage", "Home");
        //    }
        //    _context.Brands.Remove(brand);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Delete(int id)
        {
            var brand = _context.Brands.FirstOrDefault(e => e.Id == id);

            if (brand is null)
                return RedirectToAction("NotFoundPage", "Home");
            _context.Brands.Remove(brand);
            _context.SaveChanges();

            TempData["success-notification"] = "Delete Brand Successfully";

            return RedirectToAction(nameof(Index));
        }
    }
    
}
