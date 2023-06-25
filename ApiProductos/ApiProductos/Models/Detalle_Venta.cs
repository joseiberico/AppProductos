using System.ComponentModel.DataAnnotations;

namespace ApiProductos.Models
{
    public class Detalle_Venta
    {
        [Key]
        public int Id_detalle { get; set; }
        public int Venta_id { get; set; }
        public int Producto_id { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_unitario { get; set; }
    }
}
