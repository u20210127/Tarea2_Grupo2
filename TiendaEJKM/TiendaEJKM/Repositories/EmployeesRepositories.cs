using System.Data.SqlClient;
using System.Data;
using TiendaEJKM.Data;
using TiendaEJKM.Models;

namespace TiendaEJKM.Repositories
{
    public class EmployeesRepositories : IEmployeesRepositories
    {
        private readonly SqlDataAccess _dbConnection;

        public EmployeesRepositories(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<EmployeesModel> GetAll()
        {
            List<EmployeesModel> employeesList = new List<EmployeesModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_Employee, Name_Employee, Address_Employee, Phone_Employee FROM tbl_Employees";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeesModel employees = new EmployeesModel();
                            employees.id_Employee = Convert.ToInt32(reader["id_Employee"]);
                            employees.Name_Employee = reader["Name_Employee"].ToString();
                            employees.Address_Employee = reader["Address_Employee"].ToString();
                            employees.Phone_Employee = reader["Phone_Employee"].ToString();

                            employeesList.Add(employees);
                        }
                    }
                }
            }

            return employeesList;

        }

        public EmployeesModel GetEmployeesById(int id)
        {
            EmployeesModel employees = new EmployeesModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT id_Employee, Name_Employee, Address_Employee, Phone_Employee FROM tbl_Employees
                                            WHERE id_Employee = @id_Employee";

                    command.Parameters.AddWithValue("@id_Employee", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.id_Employee = Convert.ToInt32(reader["id_Employee"]);
                            employees.Name_Employee = reader["Name_Employee"].ToString();
                            employees.Address_Employee = reader["Address_Employee"].ToString();
                            employees.Phone_Employee = reader["Phone_Employee"].ToString();
                        }
                    }
                }
            }

            return employees;
        }

        public void Add(EmployeesModel employees)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tbl_Employees 
                                           VALUES(@Name_Employee, @Address_Employee, @Phone_Employee)";

                    command.Parameters.AddWithValue("@Name_Employee", employees.Name_Employee);
                    command.Parameters.AddWithValue("@Address_Employee", employees.Address_Employee);
                    command.Parameters.AddWithValue("@Phone_Employee", employees.Phone_Employee);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(EmployeesModel employees)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tbl_Employees 
                                           SET Name_Employee = @Name_Employee,
                                           Address_Employee = @Address_Employee,
                                           Phone_Employee = @Phone_Employee
                                           WHERE id_Employee = @id_Employee";

                    command.Parameters.AddWithValue("@Name_Employee", employees.Name_Employee);
                    command.Parameters.AddWithValue("@Address_Employee", employees.Address_Employee);
                    command.Parameters.AddWithValue("@Phone_Employee", employees.Phone_Employee);
                    command.Parameters.AddWithValue("@id_Employee", employees.id_Employee);

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
                    command.CommandText = @"DELETE FROM tbl_Employees
                                           WHERE id_Employee = @id_Employee";

                    command.Parameters.AddWithValue("@id_Employee", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
