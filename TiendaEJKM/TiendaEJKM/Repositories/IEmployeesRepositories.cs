using TiendaEJKM.Models;

namespace TiendaEJKM.Repositories
{
    public interface IEmployeesRepositories
    {
        IEnumerable<EmployeesModel> GetAll();

        EmployeesModel GetEmployeesById(int id);

        void Add(EmployeesModel employees);

        void Edit(EmployeesModel employees);

        void Delete(int id);
    }
}
