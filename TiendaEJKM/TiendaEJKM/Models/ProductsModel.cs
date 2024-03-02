namespace TiendaEJKM.Models
{
    public class ProductsModel
    {
        public int id_Product { get; set; }

        public string? Name_Product { get; set; }

        public string? Category_Product { get; set; }

        public decimal Price_Product { get; set; }

        public bool Availability_Product { get; set; }
    }
}
