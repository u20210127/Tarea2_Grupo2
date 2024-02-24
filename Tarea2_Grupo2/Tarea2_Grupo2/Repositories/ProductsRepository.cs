using System.Data;

namespace Tarea2_Grupo2.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public ProductsRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<ProductsModel> GetAll()
        {
            List<ProductsModel> productsList = new List<ProductsModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT Products.Id, ProductsName,
                                            SupplierId, Supplier.SupplierName
                                            FROM Products
                                            INNER JOIN Supplier
                                            ON Products.SupplierId = Supplier.Id;";

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductsModel products = new ProductsModel();
                            products.Id = Convert.ToInt32(reader["Id"]);
                            products.ProductsName = reader["ProductsName"].ToString();
                            products.SupplierId = Convert.ToInt32(reader["SupplierId"].ToString());
                            products.SupplierName = reader["SupplierName"].ToString();

                            ProductsList.Add(products);
                        }
                    }
                }
            }

            return productsList;
        }

        public IEnumerable<SupplierModel> GetAllUniversities()
        {
            List<SupplierModel> supplierList = new List<SupplierModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id, SupplierName FROM Supplier;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SupplierModel supplier = new SupplierModel();
                            supplier.Id = Convert.ToInt32(reader["ID"]);
                            supplier.SupplierName = reader["SupplierName"].ToString();

                            SupplierList.Add(Supplier);
                        }
                    }
                }
            }

            return uniList;

        }


        public void Add(ProductsModel products)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Products 
                                           VALUES(@ProductsName, @SupplierId)";

                    command.Parameters.AddWithValue("@ProductsName", products.ProductsName);
                    command.Parameters.AddWithValue("@SupplierId", products.SupplierId);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(ProductsModel products)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Products 
                                           SET ProductsName = @ProductsName,
                                           SupplierId = @SupplierId
                                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@ProductsName", products.ProductsName);
                    command.Parameters.AddWithValue("@SupplierId", products.SupplierId);
                    command.Parameters.AddWithValue("@Id", products.Id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }



        public ProductsModel? GetProductsById(int id)
        {
            ProductsModel products = new ProductsModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT Id, ProductsName, SupplierId FROM Products
                                            WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Id = Convert.ToInt32(reader["Id"]);
                            products.ProductsName = reader["ProductsName"].ToString();
                            products.SupplierId = Convert.ToInt32(reader["SupplierId"]);
                        }
                    }
                }
            }

            return products;
        }
    }

    internal class SqlCommand : IDisposable
    {
    }

    internal class SqlDataAccess
    {
    }
}

           