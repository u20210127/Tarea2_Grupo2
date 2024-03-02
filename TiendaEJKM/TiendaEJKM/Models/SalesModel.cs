using System.ComponentModel;

namespace TiendaEJKM.Models
{
    public class SalesModel
    {
        public int id_Sales { get; set; }

        public int id_Customer { get; set; }

        public int id_Product { get; set; }

        public int id_Employee { get; set; }

        public DateTime Date_Sale { get; set; }

        public decimal Total_Paid { get; set; }

        //Atributos a mostrar
        public string? Name_Customer { get; set; }
        public string? Name_Product { get; set; }
        public string? Name_Employee { get; set; }
    }
}
