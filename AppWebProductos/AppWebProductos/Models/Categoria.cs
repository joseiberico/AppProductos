using System.ComponentModel.DataAnnotations;

namespace AppWebProductos.Models
{
    public class Categoria
    {
        public int Id_Categoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
