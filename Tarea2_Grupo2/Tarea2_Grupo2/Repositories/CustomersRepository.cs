using System.Data;

namespace Tarea2_Grupo2.Repositories
{
	public class CustomersRepository : ICustomersRepository
	{
		private readonly SqlDataAccess _dbConnection;

		public CustomersRepository(SqlDataAccess dbConnection)
		{
			_dbConnection = dbConnection;
		}

		public IEnumerable<UniversityModel> GetAll()
		{
			List<UniversityModel> universityList = new List<UniversityModel>();

			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = "SELECT Id, UniversityName, Phone FROM University;";
					command.CommandType = CommandType.Text;

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							UniversityModel university = new UniversityModel();
							university.Id = Convert.ToInt32(reader["ID"]);
							university.UniversityName = reader["UniversityName"].ToString();
							university.Phone = reader["Phone"].ToString();

							universityList.Add(university);
						}
					}
				}
			}

			return universityList;

		}

		public UniversityModel? GetCustomersById(int id)
		{
			UniversityModel university = new UniversityModel();

			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"SELECT Id, UniversityName, Phone FROM University
                                            WHERE Id = @Id";

					command.Parameters.AddWithValue("@Id", id);

					command.CommandType = CommandType.Text;

					using (var reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							university.Id = Convert.ToInt32(reader["Id"]);
							university.UniversityName = reader["UniversityName"].ToString();
							university.Phone = reader["Phone"].ToString();
						}
					}
				}
			}

			return university;
		}

		public void Add(UniversityModel university)
		{
			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"INSERT INTO University 
                                           VALUES(@UniversityName, @Phone)";

					command.Parameters.AddWithValue("@UniversityName", university.UniversityName);
					command.Parameters.AddWithValue("@Phone", university.Phone);

					command.CommandType = CommandType.Text;

					command.ExecuteNonQuery();
				}
			}
		}

		public void Edit(UniversityModel university)
		{
			using (var connection = _dbConnection.GetConnection())
			{
				connection.Open();

				using (var command = new SqlCommand())
				{
					command.Connection = connection;
					command.CommandText = @"UPDATE University 
                                           SET UniversityName = @UniversityName,
                                           Phone = @Phone
                                           WHERE Id = @Id";

					command.Parameters.AddWithValue("@UniversityName", university.UniversityName);
					command.Parameters.AddWithValue("@Phone", university.Phone);
					command.Parameters.AddWithValue("@Id", university.Id);

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
					command.CommandText = @"DELETE FROM UniversityName
                                           WHERE Id = @Id";

					command.Parameters.AddWithValue("@Id", id);

					command.CommandType = CommandType.Text;

					command.ExecuteNonQuery();
				}
			}
		}

	}
}
