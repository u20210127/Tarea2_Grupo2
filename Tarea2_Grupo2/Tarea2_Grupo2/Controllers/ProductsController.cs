using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Tarea2_Grupo2; 
using Tarea2_Grupo2.Models;

namespace Tarea2_Grupo2.Controllers
{
    public class ProductsController : Controller
    {
            private readonly IProductsRepository _productsRepository;

            public ProductsController(IProductsRepository productsRepository)
            {
                _productsRepository = productsRepository;
            }

            public IActionResult Index()
            {
                return View(_productsRepository.GetAll());
            }

            [HttpGet]
            public IActionResult Create()
            {
                var universities = _productsRepository.GetAllUniversities();

                ViewBag.Universities = new SelectList(universities,
                                           nameof(SupplierModel.Id),
                                           nameof(SupplierModel.SupplierName));

                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(ProductsModel products)
            {
                try
                {
                    _productsRepository.Add(products);

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                    return View(products);
                }
            }

            [HttpGet]
            public IActionResult Edit(int id)
            {
                var products = _productsRepository.GetProductsById(id);
                var universities = _productsRepository.GetAllUniversities();

                if (products == null)
                {
                    return NotFound();
                }

                ViewBag.Universities = new SelectList(
                                           universities,
                                           nameof(SupplierModel.Id),
                                           nameof(SupplierModel.SupplierName),
                                           products?.SupplierId
                                           );

                return View(products);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(ProductsModel products)
            {
                try
                {
                    _productsRepository.Edit([products]);

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