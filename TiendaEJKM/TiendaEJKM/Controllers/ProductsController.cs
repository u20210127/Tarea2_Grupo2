using FluentValidation;
using FluentValidation.Results;
using TiendaEJKM.Validations;
using Microsoft.AspNetCore.Mvc;
using TiendaEJKM.Models;
using TiendaEJKM.Repositories;

namespace TiendaEJKM.Controllers
{
    public class ProductsController : Controller
    {
        private IValidator<ProductsModel> _ProductsValidator;
        private readonly IProductsRepositories _ProductsRepository;

        public ProductsController(IProductsRepositories ProductsRepository, IValidator<ProductsModel> ProductsValidator)
        {
            _ProductsValidator = ProductsValidator;
            _ProductsRepository = ProductsRepository;
        }

        public ActionResult Index()
        {
            return View(_ProductsRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsModel products)
        {
            ValidationResult validationResult = _ProductsValidator.Validate(products);

            try
            {
                _ProductsRepository.Add(products);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                validationResult.AddToModelState(this.ModelState);

                return View(products);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var products = _ProductsRepository.GetProductsById(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsModel products)
        {
            try
            {
                _ProductsRepository.Edit(products);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(products);

            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var products = _ProductsRepository.GetProductsById(id);

            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(ProductsModel products)
        {
            try
            {
                _ProductsRepository.Delete(products.id_Product);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(products);

            }

        }
    }
}
