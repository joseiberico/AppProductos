using System.ComponentModel.DataAnnotations;

namespace ApiProductos.Models
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
