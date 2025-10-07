using Microsoft.AspNetCore.Mvc;

namespace EC01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
