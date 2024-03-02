using TiendaEJKM.Models;

namespace TiendaEJKM.Repositories
{
    public interface ISalesRepositories
    {
        IEnumerable<SalesModel> GetAll();

        SalesModel GetSalesById(int id);

        void Add(SalesModel sales);

        void Edit(SalesModel sales);

        void Delete(int id);

        IEnumerable<CustomersModel> GetAllCustomers();

        IEnumerable<EmployeesModel> GetAllEmployees();

        IEnumerable<ProductsModel> GetAllProducts();
    }
}
