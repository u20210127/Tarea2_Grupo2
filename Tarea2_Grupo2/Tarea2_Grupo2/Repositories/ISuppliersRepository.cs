using Tarea2_Grupo2.Models;

namespace Tarea2_Grupo2.Repositories
{
    public interface ISuppliersRepository
    {
        IEnumerable<SuppliersModel> GetAll();

        SuppliersModel GetSuppliersById(int id);

        void Add(SuppliersModel suppliers);

        void Edit(SuppliersModel suppliers);

        void Delete(int id);
    }
}
