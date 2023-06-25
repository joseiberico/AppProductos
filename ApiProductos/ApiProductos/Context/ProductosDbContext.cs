using ApiProductos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProductos.Context
{
    public class ProductosDbContext : DbContext
    {
        public ProductosDbContext(DbContextOptions<ProductosDbContext> options) : base(options) { }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Detalle_Venta> Detalle_Venta { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venta> Venta { get; set; }

    }
}
