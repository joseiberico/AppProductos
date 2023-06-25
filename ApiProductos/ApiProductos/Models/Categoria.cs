using System.ComponentModel.DataAnnotations;

namespace ApiProductos.Models
{
    public class Categoria
    {
        [Key]
        public int Id_Categoria { get; set; }
        public string Nombre { get; set; }
        public string descripcion { get; set; }
    }
}
