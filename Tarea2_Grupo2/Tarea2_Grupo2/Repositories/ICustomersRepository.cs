
using Tarea2_Grupo2.Models;

namespace Tarea2_Grupo2.Repositories
{
	public interface ICustomersRepository
	{
		IEnumerable<CustomersModel> GetAll();

		CustomersModel GetCustomersById(int id);

		void Add(CustomersModel customer);

		void Edit(CustomersModel customer);

		void Delete(int id);
	}
}
