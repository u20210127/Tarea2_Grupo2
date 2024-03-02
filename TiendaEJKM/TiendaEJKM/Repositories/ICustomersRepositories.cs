using TiendaEJKM.Models;

namespace TiendaEJKM.Repositories
{
    public interface ICustomersRepositories
    {
        IEnumerable<CustomersModel> GetAll();

        CustomersModel GetCustomersById(int id);

        void Add(CustomersModel customers);

        void Edit(CustomersModel customers);

        void Delete(int id);
    }
}
