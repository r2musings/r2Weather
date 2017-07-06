using Microsoft.AspNetCore.Mvc;

namespace r2weathernet.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}