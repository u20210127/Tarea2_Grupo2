namespace Tarea2_Grupo2.Models
{
    public class ProductsModel
    {
        public int id_Producto { get; set; }
        public int id_Proveedor { get; set; }
        public string? Nombre_Producto { get; set; }
        public string? Nombre_Proveedor { get; set; }
        public string? Categoria {  get; set; }
        public string? Precio { get; set; }
        public string? Disponibilidad { get; set; }
        
    }
}
