using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoAspNetMVC.Presentation.Controllers
{
    [Authorize] //Permitir somente usuarios autenticados!
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
