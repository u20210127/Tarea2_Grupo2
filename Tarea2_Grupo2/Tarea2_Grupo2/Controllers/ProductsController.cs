using Microsoft.AspNetCore.Mvc;

namespace Tarea2_Grupo2.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
