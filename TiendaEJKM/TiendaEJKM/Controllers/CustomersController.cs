using FluentValidation;
using FluentValidation.Results;
using TiendaEJKM.Validations;
using Microsoft.AspNetCore.Mvc;
using TiendaEJKM.Models;
using TiendaEJKM.Repositories;

namespace TiendaEJKM.Controllers
{
    public class CustomersController : Controller
    {
        private IValidator<CustomersModel> _CustomersValidator;
        private readonly ICustomersRepositories _CustomersRepository;

        public CustomersController(ICustomersRepositories CustomersRepository, IValidator<CustomersModel> CustomersValidator)
        {
            _CustomersValidator = CustomersValidator;
            _CustomersRepository = CustomersRepository;
        }

        public ActionResult Index()
        {
            return View(_CustomersRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersModel customers)
        {
            ValidationResult validationResult = _CustomersValidator.Validate(customers);

            try
            {
                _CustomersRepository.Add(customers);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                validationResult.AddToModelState(this.ModelState);

                return View(customers);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customers = _CustomersRepository.GetCustomersById(id);
            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersModel customers)
        {
            try
            {
                _CustomersRepository.Edit(customers);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(customers);

            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customers = _CustomersRepository.GetCustomersById(id);

            if (customers == null)
            {
                return NotFound();
            }
            return View(customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CustomersModel customers)
        {
            try
            {
                _CustomersRepository.Delete(customers.id_Customer);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(customers);

            }

        }
    }
}
