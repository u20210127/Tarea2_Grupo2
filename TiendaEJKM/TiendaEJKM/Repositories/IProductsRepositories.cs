using TiendaEJKM.Models;

namespace TiendaEJKM.Repositories
{
    public interface IProductsRepositories
    {
        IEnumerable<ProductsModel> GetAll();

        ProductsModel GetProductsById(int id);

        void Add(ProductsModel products);

        void Edit(ProductsModel products);

        void Delete(int id);
    }
}
