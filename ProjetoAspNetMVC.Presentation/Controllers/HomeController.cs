using Microsoft.AspNetCore.Mvc;

namespace ProjetoAspNetMVC.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
