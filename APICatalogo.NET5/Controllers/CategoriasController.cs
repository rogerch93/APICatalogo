using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.NET5.Controllers
{
    public class CategoriasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
