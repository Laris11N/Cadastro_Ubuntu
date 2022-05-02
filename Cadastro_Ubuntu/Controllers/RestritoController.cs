//using Cadastro_Ubuntu.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_Ubuntu.Controllers
{
   //[PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
