using System.Data;
using Tarea2_Grupo2.Models;

namespace Tarea2_Grupo2.Repositories
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly SqlDataAccess _dbConnection;

        public SuppliersRepository(SqlDataAccess dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<SuppliersModel> GetAll()
        {
            List<SuppliersModel> suppliersList = new List<SuppliersModel>();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT id_Proveedor, Nombre_Proveedor, Direccion, Telefono FROM tbl_Proveedores;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SuppliersModel suppliers = new SuppliersModel();
                            suppliers.id_Proveedor = Convert.ToInt32(reader["id_Proveedor"]);
                            suppliers.Nombre_Proveedor = reader["Nombre_Proveedor"].ToString();
                            suppliers.Direccion = reader["Direccion "].ToString();
                            suppliers.Telefono = Convert.ToInt32(reader["Telefono"]);
                            suppliersList.Add(suppliers);
                        }
                    }
                }
            }

            return suppliersList;

        }

        public SuppliersModel? GetSuppliersById(int id)
        {
            SuppliersModel suppliers = new SuppliersModel();

            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT id_Proveedor, Nombre_Proveedor, Direccion, Telefono FROM tbl_Proveedores
                                            WHERE id_Proveedor = @id_Proveedor";

                    command.Parameters.AddWithValue("@id_Proveedor", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.id_Proveedor = Convert.ToInt32(reader["id_Proveedor"]);
                            suppliers.Nombre_Proveedor = reader["Nombre_Proveedor"].ToString();
                            suppliers.Direccion = reader["Direccion "].ToString();
                            suppliers.Telefono = Convert.ToInt32(reader["Telefono"]);
                        }
                    }
                }
            }

            return suppliers;
        }

        public void Add(SuppliersModel suppliers)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tbl_Proveedores 
                                           VALUES(@Nombre_Proveedor, @Direccion, @Telefono)";

                    command.Parameters.AddWithValue("@Nombre_Proveedor", suppliers.Nombre_Proveedor);
                    command.Parameters.AddWithValue("@Direccion", suppliers.Direccion);
                    command.Parameters.AddWithValue("@Telefono", suppliers.Telefono);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(SuppliersModel suppliers)
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tbl_Proveedores 
                                           SET Nombre_Proveedor = @Nombre_Proveedor,
                                           Direccion = @Direccion,
                                           Telefono = @Telefono
                                           WHERE id_Proveedor = @id_Proveedor";

                    command.Parameters.AddWithValue("@Nombre_Proveedor", suppliers.Nombre_Proveedor);
                    command.Parameters.AddWithValue("@Direccion", suppliers.Direccion);
                    command.Parameters.AddWithValue("@Telefono", suppliers.Telefono);

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
                    command.CommandText = @"DELETE FROM Nombre_Proveedor
                                           WHERE id_Proveedor = @id_Proveedor";

                    command.Parameters.AddWithValue("@id_Proveedor", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
