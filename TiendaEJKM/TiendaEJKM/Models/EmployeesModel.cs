using System.ComponentModel;

namespace TiendaEJKM.Models
{
    public class EmployeesModel
    {
        public int id_Employee { get; set; }
        [DisplayName("Nombre")]
        public string? Name_Employee { get; set; }
        [DisplayName("Direccion")]
        public string? Address_Employee { get; set; }
        [DisplayName("Teléfono")]
        public string? Phone_Employee { get; set; }
    }
}
