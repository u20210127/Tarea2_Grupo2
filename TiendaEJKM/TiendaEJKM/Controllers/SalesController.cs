using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TiendaEJKM.Models;
using TiendaEJKM.Repositories;

namespace TiendaEJKM.Controllers
{
    public class SalesController : Controller
    {

        private IValidator<SalesModel> _SalesValidator;
        private readonly ISalesRepositories _SalesRepository;
        private readonly IEmployeesRepositories _EmployeesRepository;
        private readonly IProductsRepositories _ProductsRepository;
        private readonly ICustomersRepositories _CustomersRepository;


        public SalesController(ISalesRepositories SalesRepository, IEmployeesRepositories EmployeesRepository, IProductsRepositories ProductsRepository, ICustomersRepositories CustomersRepository, IValidator<SalesModel> SalesValidator)
        {
            _SalesValidator = SalesValidator;
            _SalesRepository = SalesRepository;
            _EmployeesRepository = EmployeesRepository;
            _ProductsRepository = ProductsRepository;   
            _CustomersRepository = CustomersRepository;
        }

        public IActionResult Index()
        {
            return View(_SalesRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            var customers = _CustomersRepository.GetAll();
            ViewBag.tbl_Customers = new SelectList(customers, nameof(CustomersModel.id_Customer), nameof(CustomersModel.Name_Customer));

            var products = _ProductsRepository.GetAll();
            ViewBag.tbl_Products = new SelectList(products, nameof(ProductsModel.id_Product), nameof(ProductsModel.Name_Product));

            var employees = _EmployeesRepository.GetAll();
            ViewBag.tbl_Employees = new SelectList(employees, nameof(EmployeesModel.id_Employee), nameof(EmployeesModel.Name_Employee));

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SalesModel sales)
        {
            try
            {
                _SalesRepository.Add(sales);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(sales);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var sales = _SalesRepository.GetSalesById(id);
            var customers = _SalesRepository.GetAllCustomers();
            var products = _SalesRepository.GetAllProducts();
            var employees = _SalesRepository.GetAllEmployees();

            if (sales == null)
            {
                return NotFound();
            }

            ViewBag.tbl_Customers = new SelectList(customers, nameof(CustomersModel.id_Customer), nameof(CustomersModel.Name_Customer), sales?.id_Customer);
            ViewBag.tbl_Products = new SelectList(products, nameof(ProductsModel.id_Product), nameof(ProductsModel.Name_Product), sales?.id_Product);
            ViewBag.tbl_Employees = new SelectList(employees, nameof(EmployeesModel.id_Employee), nameof(EmployeesModel.Name_Employee), sales?.id_Employee);

            return View(sales);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SalesModel sales)
        {
            try
            {
                _SalesRepository.Edit(sales);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(sales);

            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var sales = _SalesRepository.GetSalesById(id);

            if (sales == null)
            {
                return NotFound();
            }

            return View(sales);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(SalesModel sales)
        {
            try
            {
                _SalesRepository.Delete(sales.id_Sales);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(sales);

            }
        }
    }
}
