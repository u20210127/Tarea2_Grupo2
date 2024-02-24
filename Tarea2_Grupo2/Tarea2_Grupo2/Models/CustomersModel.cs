using System.ComponentModel;

namespace Tarea2_Grupo2.Models
{
    public class CustomersModel
    {

		public int Id_Clientes{ get; set; }

		[DisplayName("Nombre_Cliente")]
		public string Nombre_Cliente { get; set; }

		[DisplayName("direccion cliente")]
		public string Direccion_Cliente { get; set; }

		[DisplayName("telefono cliene")]
		public int Telefono_Cliente { get; set; }
	}
}
