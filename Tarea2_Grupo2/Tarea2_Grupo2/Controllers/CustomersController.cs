using Microsoft.AspNetCore.Mvc;
using Tarea2_Grupo2.Models;
using Tarea2_Grupo2.Repositories;

namespace Tarea2_Grupo2.Controllers
{
    public class CustomerController : Controller
	{
		private readonly ICustomersRepository _CustomersRepository;

		public CustomerController(ICustomersRepository CustomersRepository)
		{
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
		public ActionResult Create(CustomersModel Customers)
		{
			if (!ModelState.IsValid)
			{
				return View(Customers);
			}

			_CustomersRepository.Add(Customers);

			return RedirectToAction(nameof(Index));
		}
	}
}
