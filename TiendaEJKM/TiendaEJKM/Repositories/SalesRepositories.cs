using TiendaEJKM.Models;
using TiendaEJKM.Data;
using System.Data.SqlClient;
using System.Data;


namespace TiendaEJKM.Repositories
{
    public class SalesRepositories : ISalesRepositories
    {
        private readonly SqlDataAccess _dbConnection;

        public SalesRepositories(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<SalesModel> GetAll()
        {
            List<SalesModel> SalesList = new List<SalesModel>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT tbl_Sales.id_Sales, tbl_Customers.id_Customer, tbl_Customers.Name_Customer,
                                            tbl_Products.id_Product, tbl_Products.Name_Product, tbl_Employees.id_Employee, tbl_Employees.Name_Employee, 
                                            tbl_Sales.Date_Sale, tbl_Sales.Total_Paid
                                            FROM tbl_Sales INNER JOIN tbl_Customers ON tbl_Sales.id_Customer = tbl_Customers.id_Customer
                                            INNER JOIN tbl_Products ON tbl_Sales.id_Product = tbl_Products.id_Product
                                            INNER JOIN tbl_Employees ON tbl_Sales.id_Employee = tbl_Employees.id_Employee";

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesModel sales = new SalesModel();
                            sales.id_Sales = Convert.ToInt32(reader["id_Sales"]);
                            sales.id_Customer = Convert.ToInt32(reader["id_Customer"]);
                            sales.Name_Customer = reader["Name_Customer"].ToString();
                            sales.id_Product = Convert.ToInt32(reader["id_Product"]);
                            sales.Name_Product = reader["Name_Product"].ToString();
                            sales.id_Employee = Convert.ToInt32(reader["id_Employee"]);
                            sales.Name_Employee = reader["Name_Employee"].ToString();
                            sales.Date_Sale = Convert.ToDateTime(reader["Date_Sale"]);
                            sales.Total_Paid = Convert.ToDecimal(reader["Total_Paid"]);
                            SalesList.Add(sales);
                        }
                    }
                }
            }
            return SalesList;
        }

        public IEnumerable<CustomersModel> GetAllCustomers()
        {
            List<CustomersModel> customersList = new List<CustomersModel>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_Customer, Name_Customer FROM tbl_Customers;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomersModel customers = new CustomersModel();
                            customers.id_Customer = Convert.ToInt32(reader["id_Customer"]);
                            customers.Name_Customer = reader["Name_Customer"].ToString();

                            customersList.Add(customers);
                        }
                    }
                }
            }
            return customersList;
        }

        public IEnumerable<ProductsModel> GetAllProducts()
        {
            List<ProductsModel> productsList = new List<ProductsModel>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_Product, Name_Product FROM tbl_Products;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductsModel products = new ProductsModel();
                            products.id_Product = Convert.ToInt32(reader["id_Product"]);
                            products.Name_Product = reader["Name_Product"].ToString();

                            productsList.Add(products);
                        }
                    }
                }
            }
            return productsList;
        }

        public IEnumerable<EmployeesModel> GetAllEmployees()
        {
            List<EmployeesModel> employeesList = new List<EmployeesModel>();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_Employee, Name_Employee FROM tbl_Employees;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeesModel employees = new EmployeesModel();
                            employees.id_Employee = Convert.ToInt32(reader["id_Employee"]);
                            employees.Name_Employee = reader["Name_Employee"].ToString();

                            employeesList.Add(employees);
                        }
                    }
                }
            }
            return employeesList;
        }

        public SalesModel GetSalesById(int id)
        {
            SalesModel sales = new SalesModel();
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT id_Sales, id_Customer, id_Product, id_Employee, Date_Sale, Total_Paid
                                            FROM tbl_Sales WHERE id_Sales = @id_Sales";

                    command.Parameters.AddWithValue("@id_Sales", id);
                    command.CommandType = CommandType.Text;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sales.id_Sales = Convert.ToInt32(reader["id_Sales"]);
                            sales.id_Customer = Convert.ToInt32(reader["id_Customer"]);
                            sales.id_Product = Convert.ToInt32(reader["id_Product"]);
                            sales.id_Employee = Convert.ToInt32(reader["id_Employee"]);
                            sales.Date_Sale = Convert.ToDateTime(reader["Date_Sale"]);
                            sales.Total_Paid = Convert.ToDecimal(reader["Total_Paid"]);

                        }
                    }
                }
            }
            return sales;
        }
        public void Add(SalesModel sales)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tbl_Sales 
                                            VALUES (@id_Customer, @id_Product, @id_Employee, @Date_Sale, @Total_Paid)";

                    command.Parameters.AddWithValue("@id_Customer", sales.id_Customer);
                    command.Parameters.AddWithValue("@id_Product", sales.id_Product);
                    command.Parameters.AddWithValue("@id_Employee", sales.id_Employee);
                    command.Parameters.AddWithValue("@Date_Sale", sales.Date_Sale);
                    command.Parameters.AddWithValue("@Total_Paid", sales.Total_Paid);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(SalesModel sales)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tbl_Sales SET id_Customer = @id_Customer,
                                            id_Product = @id_Product, id_Employee = @id_Employee,
                                            Date_Sale = @Date_Sale,
                                            Total_Paid = @Total_Paid WHERE id_Sales = @id_Sales";

                    command.Parameters.AddWithValue("@id_Customer", sales.id_Customer);
                    command.Parameters.AddWithValue("@id_Product", sales.id_Product);
                    command.Parameters.AddWithValue("@id_Employee", sales.id_Employee);
                    command.Parameters.AddWithValue("@Date_Sale", sales.Date_Sale);
                    command.Parameters.AddWithValue("@Total_Paid", sales.Total_Paid);
                    command.Parameters.AddWithValue("@id_Sales", sales.id_Sales);

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
                    command.CommandText = @"DELETE FROM tbl_Sales WHERE id_Sales = @id_Sales;";
                    command.Parameters.AddWithValue("@id_Sales", id);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
