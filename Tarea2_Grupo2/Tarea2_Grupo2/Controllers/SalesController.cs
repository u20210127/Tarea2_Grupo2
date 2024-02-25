using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tarea2_Grupo2.Repositories;

namespace Tarea2_Grupo2.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesRepository _salesRepository;

        public SalesController(ISalesRepository salesRepository)
        {
            _salesRepository = salesRepository;
        }

        public IActionResult Index()
        {
            return View(_salesRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var customers = _salesRepository.GetAllCustomers();
            var products = _salesRepository.GetAllProducts();

            ViewBag.Customers = new SelectList(customers, products,
                                       nameof(CustomersModel.id_Cliente),
                                       nameof(ProductsModel.id_Producto));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FacultyModel faculty)
        {
            try
            {
                _facultyRepository.Add(faculty);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(faculty);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var faculty = _facultyRepository.GetFacultyById(id);
            var universities = _facultyRepository.GetAllUniversities();

            if (faculty == null)
            {
                return NotFound();
            }

            ViewBag.Universities = new SelectList(
                                       universities,
                                       nameof(UniversityModel.Id),
                                       nameof(UniversityModel.UniversityName),
                                       faculty?.UniversityId
                                       );

            return View(faculty);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FacultyModel faculty)
        {
            try
            {
                _facultyRepository.Edit(faculty);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(faculty);

            }
        }
    }
}
