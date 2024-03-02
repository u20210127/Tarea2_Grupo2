using FluentValidation;
using FluentValidation.Results;
using TiendaEJKM.Validations;
using Microsoft.AspNetCore.Mvc;
using TiendaEJKM.Models;
using TiendaEJKM.Repositories;

namespace TiendaEJKM.Controllers
{
    public class EmployeesController : Controller
    {
        private IValidator<EmployeesModel> _EmployeesValidator;
        private readonly IEmployeesRepositories _EmployeesRepository;

        public EmployeesController(IEmployeesRepositories EmployeeRepository, IValidator<EmployeesModel> EmployeeValidator)
        {
            _EmployeesValidator = EmployeeValidator;
            _EmployeesRepository = EmployeeRepository;
        }

        public ActionResult Index()
        {
            return View(_EmployeesRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeesModel employees)
        {
            ValidationResult validationResult = _EmployeesValidator.Validate(employees);

            try
            {
                _EmployeesRepository.Add(employees);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                validationResult.AddToModelState(this.ModelState);

                return View(employees);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var employees = _EmployeesRepository.GetEmployeesById(id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeesModel employees)
        {
            try
            {
                _EmployeesRepository.Edit(employees);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(employees);

            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employees = _EmployeesRepository.GetEmployeesById(id);

            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeesModel employees)
        {
            try
            {
                _EmployeesRepository.Delete(employees.id_Employee);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(employees);

            }

        }
    }
}
