using EC01.Models;
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
            //Request.Cookies[];
            //Response.Cookies.Append();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Brand brand, IFormFile img)
        {
            if (img is not null && img.Length > 0)
            {
                // save img in wwwroot
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);// sdfgfds-sdfbg-fdgg-gxf
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
            //Response.Cookies.Append("Notifcation","Brand Added successfully");
            TempData["Notifcation"] = "Brand Added successfully";
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
        public IActionResult Edit(Brand brand, IFormFile? img)
        {
            var brandInDb = _context.Brands.AsNoTracking().FirstOrDefault(e => e.Id == brand.Id);
            if (brandInDb is null)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }

            if (img is not null && img.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    img.CopyTo(stream);
                }
                // remove old img from wwwroot
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", brandInDb.Img);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
                // save img in db
                brand.Img = fileName;
            }
            else
            {
                brand.Img = brandInDb.Img;
            }
            _context.Brands.Update(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var brand = _context.Brands.FirstOrDefault(e => e.Id == id);
            if (brand is null)
                return RedirectToAction("NotFoundPage", "Home");
            // remove old img from wwwroot
            var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", brand.Img);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }
            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
