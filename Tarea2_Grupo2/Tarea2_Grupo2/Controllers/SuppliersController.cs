using Microsoft.AspNetCore.Mvc;

namespace Tarea2_Grupo2.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliersRepository _suppliersRepository;

        public SuppliersController(ISuppliersRepository suppliersRepository)
        {
            _suppliersRepository = suppliersRepository;
        }

        public ActionResult Index()
        {
            return View(_suppliersRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliersModel suppliers)
        {
            if (!ModelState.IsValid)
            {
                return View(suppliers);
            }

            _suppliersRepository.Add(suppliers);

            return RedirectToAction(nameof(Index));
        }
    }
}
