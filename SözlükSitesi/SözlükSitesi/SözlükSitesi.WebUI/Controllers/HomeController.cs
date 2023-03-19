using Microsoft.AspNetCore.Mvc;

namespace SözlükSitesi.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
