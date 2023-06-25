using System.ComponentModel.DataAnnotations;

namespace ApiProductos.Models
{
    public class Productos
    {
        [Key]
        public int Id_Producto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Categoria_id { get; set; }
    }
}
