using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC.Presentation.Controllers
{
    public class TarefasController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Consulta()
        {
            return View();
        }
        public IActionResult Relatorio()
        {
            return View();
        }
    }
}
