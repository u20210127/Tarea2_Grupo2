using System.Data.SqlClient;
using System.Data;
using TiendaEJKM.Data;
using TiendaEJKM.Models;

namespace TiendaEJKM.Repositories
{
    public class ProductsRepositories : IProductsRepositories
    {
        private readonly SqlDataAccess _dbConnection;

        public ProductsRepositories(SqlDataAccess dbConnection)
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
                    command.CommandText = "SELECT id_Product, Name_Product, Category_Product, Price_Product, Availability_Product FROM tbl_Products";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductsModel products = new ProductsModel();
                            products.id_Product = Convert.ToInt32(reader["id_Product"]);
                            products.Name_Product = reader["Name_Product"].ToString();
                            products.Category_Product = reader["Category_Product"].ToString();
                            products.Price_Product = Convert.ToDecimal(reader["Price_Product"]);
                            products.Availability_Product = Convert.ToBoolean(reader["Availability_Product"]);

                            productsList.Add(products);
                        }
                    }
                }
            }

            return productsList;

        }

        public ProductsModel GetProductsById(int id)
        {
            ProductsModel products = new ProductsModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT id_Product, Name_Product, Category_Product, Price_Product, Availability_Product FROM tbl_Products
                                            WHERE id_Product = @id_Product";

                    command.Parameters.AddWithValue("@id_Product", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.id_Product = Convert.ToInt32(reader["id_Product"]);
                            products.Name_Product = reader["Name_Product"].ToString();
                            products.Category_Product = reader["Category_Product"].ToString();
                            products.Price_Product = Convert.ToDecimal(reader["Price_Product"]);
                            products.Availability_Product = Convert.ToBoolean(reader["Availability_Product"]);
                        }
                    }
                }
            }

            return products;
        }

        public void Add(ProductsModel products)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tbl_Products 
                                           VALUES(@Name_Product, @Category_Product, @Price_Product, @Availability_Product)";

                    command.Parameters.AddWithValue("@Name_Product", products.Name_Product);
                    command.Parameters.AddWithValue("@Category_Product", products.Category_Product);
                    command.Parameters.AddWithValue("@Price_Product", products.Price_Product);
                    command.Parameters.AddWithValue("@Availability_Product", products.Availability_Product);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(ProductsModel products)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tbl_Products 
                                           SET Name_Product = @Name_Product,
                                           Category_Product = @Category_Product,
                                           Price_Product = @Price_Product,
                                           Availability_Product = @Availability_Product
                                           WHERE id_Product = @id_Product";

                    command.Parameters.AddWithValue("@Name_Product", products.Name_Product);
                    command.Parameters.AddWithValue("@Category_Product", products.Category_Product);
                    command.Parameters.AddWithValue("@Price_Product", products.Price_Product);
                    command.Parameters.AddWithValue("@Availability_Product", products.Availability_Product);
                    command.Parameters.AddWithValue("@id_Product", products.id_Product);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM tbl_Products
                                           WHERE id_Product = @id_Product";

                    command.Parameters.AddWithValue("@id_Product", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
