using Tarea2_Grupo2.Models;

namespace Tarea2_Grupo2.Repositories
{
    public interface IProductsRepository
    {
            IEnumerable<ProductsModel> GetAll();

            ProductsModel GetProductsById(int id);

            void Add(ProductsModel products);

            void Edit(ProductsModel products);

            void Delete(int id);
            IEnumerable<SupplierModel> GetAllSupplier();
        }
    }