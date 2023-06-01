using Microsoft.AspNetCore.Mvc;

namespace MyLeasing.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
