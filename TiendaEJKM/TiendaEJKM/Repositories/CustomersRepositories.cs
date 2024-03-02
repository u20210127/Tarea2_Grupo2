using System.Data.SqlClient;
using System.Data;
using TiendaEJKM.Data;
using TiendaEJKM.Models;
using TiendaEJKM.Validations;

namespace TiendaEJKM.Repositories
{
    public class CustomersRepositories : ICustomersRepositories
    {
        private readonly SqlDataAccess _dbConnection;

        public CustomersRepositories(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<CustomersModel> GetAll()
        {
            List<CustomersModel> customersList = new List<CustomersModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_Customer, Name_Customer, Address_Customer, Phone_Customer FROM tbl_Customers";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomersModel customers = new CustomersModel();
                            customers.id_Customer = Convert.ToInt32(reader["id_Customer"]);
                            customers.Name_Customer = reader["Name_Customer"].ToString();
                            customers.Address_Customer = reader["Address_Customer"].ToString();
                            customers.Phone_Customer = reader["Phone_Customer"].ToString();

                            customersList.Add(customers);
                        }
                    }
                }
            }

            return customersList;

        }

        public CustomersModel GetCustomersById(int id)
        {
            CustomersModel customers = new CustomersModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT id_Customer, Name_Customer, Address_Customer, Phone_Customer FROM tbl_Customers
                                            WHERE id_Customer = @id_Customer";

                    command.Parameters.AddWithValue("@id_Customer", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.id_Customer = Convert.ToInt32(reader["id_Customer"]);
                            customers.Name_Customer = reader["Name_Customer"].ToString();
                            customers.Address_Customer = reader["Address_Customer"].ToString();
                            customers.Phone_Customer = reader["Phone_Customer"].ToString();
                        }
                    }
                }
            }

            return customers;
        }

        public void Add(CustomersModel customers)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tbl_Customers 
                                           VALUES(@Name_Customer, @Address_Customer, @Phone_Customer)";

                    command.Parameters.AddWithValue("@Name_Customer", customers.Name_Customer);
                    command.Parameters.AddWithValue("@Address_Customer", customers.Address_Customer);
                    command.Parameters.AddWithValue("@Phone_Customer", customers.Phone_Customer);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(CustomersModel customers)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tbl_Customers 
                                           SET Name_Customer = @Name_Customer,
                                           Address_Customer = @Address_Customer,
                                           Phone_Customer = @Phone_Customer
                                           WHERE id_Customer = @id_Customer";

                    command.Parameters.AddWithValue("@Name_Customer", customers.Name_Customer);
                    command.Parameters.AddWithValue("@Address_Customer", customers.Address_Customer);
                    command.Parameters.AddWithValue("@Phone_Customer", customers.Phone_Customer);
                    command.Parameters.AddWithValue("@id_Customer", customers.id_Customer);

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
                    command.CommandText = @"DELETE FROM tbl_Customers
                                           WHERE id_Customer = @id_Customer";

                    command.Parameters.AddWithValue("@id_Customer", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
