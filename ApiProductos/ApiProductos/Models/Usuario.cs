using System.ComponentModel.DataAnnotations;

namespace ApiProductos.Models
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
    }
}
