using Tarea2_Grupo2.Data;
using Tarea2_Grupo2.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Tarea2_Grupo2.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public SalesRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<SalesModel> GetAll()
        {
            List<SalesModel> salesList = new List<SalesModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT Faculty.Id, FacultyName,
                                            UniversityId, University.UniversityName
                                            FROM Faculty
                                            INNER JOIN University
                                            ON Faculty.UniversityId = University.Id;";

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalesModel sales = new SalesModel();
                            sales.Id = Convert.ToInt32(reader["Id"]);
                            sales.FacultyName = reader["FacultyName"].ToString();
                            sales.UniversityId = Convert.ToInt32(reader["UniversityId"].ToString());
                            sales.UniversityName = reader["UniversityName"].ToString();

                            salesList.Add(sales);
                        }
                    }
                }
            }

            return salesList;
        }

        public IEnumerable<CustomersModel> GetAllCustomers()
        {
            List<CustomersModel> universityList = new List<CustomersModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id, UniversityName FROM University;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomersModel university = new CustomersModel();
                            university.Id = Convert.ToInt32(reader["ID"]);
                            university.UniversityName = reader["UniversityName"].ToString();

                            universityList.Add(university);
                        }
                    }
                }
            }

            return universityList;

        }

        public IEnumerable<ProductsModel> GetAllProducts()
        {
            List<ProductsModel> universityList = new List<ProductsModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id, UniversityName FROM University;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductsModel university = new ProductsModel();
                            university.Id = Convert.ToInt32(reader["ID"]);
                            university.UniversityName = reader["UniversityName"].ToString();

                            universityList.Add(university);
                        }
                    }
                }
            }

            return universityList;

        }


        public void Add(SalesModel faculty)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Faculty 
                                           VALUES(@FacultyName, @UniversityId)";

                    command.Parameters.AddWithValue("@FacultyName", faculty.FacultyName);
                    command.Parameters.AddWithValue("@UniversityId", faculty.UniversityId);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(SalesModel faculty)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Faculty 
                                           SET FacultyName = @FacultyName,
                                           UniversityId = @UniversityId
                                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@FacultyName", faculty.FacultyName);
                    command.Parameters.AddWithValue("@UniversityId", faculty.UniversityId);
                    command.Parameters.AddWithValue("@Id", faculty.Id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }



        public SalesModel? GetSalesById(int id)
        {
            SalesModel faculty = new SalesModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT Id, FacultyName, UniversityId FROM Faculty
                                            WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            faculty.Id = Convert.ToInt32(reader["Id"]);
                            faculty.FacultyName = reader["FacultyName"].ToString();
                            faculty.UniversityId = Convert.ToInt32(reader["UniversityId"]);
                        }
                    }
                }
            }

            return faculty;
        }
    }
}
