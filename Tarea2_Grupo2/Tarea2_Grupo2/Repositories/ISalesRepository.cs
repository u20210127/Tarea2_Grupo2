using Tarea2_Grupo2.Models;

namespace Tarea2_Grupo2.Repositories
{
    public interface ISalesRepository
    {
        IEnumerable<SalesModel> GetAll();

        SalesModel GetCustomersById(int id);

        void Add(SalesModel customers);

        void Edit(SalesModel customers);

        void Delete(int id);
        IEnumerable<CustomersModel> GetAllCustomers();
        IEnumerable<ProductsModel> GetAllProducts();
    }
}
