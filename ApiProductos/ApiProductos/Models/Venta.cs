using System.ComponentModel.DataAnnotations;

namespace ApiProductos.Models
{
    public class Venta
    {
        [Key]
        public int Id_Venta { get; set; }
        public DateTime Fecha_venta { get; set; }
        public int Cliente_id { get; set; }
        public int Usuario_id { get; set; }

    }
}
