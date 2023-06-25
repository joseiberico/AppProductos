using ApiProductos.Context;
using ApiProductos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiProductos.Repository
{
    public class ProductosRepository : iRepository.IRepository<Productos>
    {
        private readonly DbSet<Productos> _DbSet;
        private readonly ProductosDbContext _context;

        public ProductosRepository(ProductosDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Productos>();
        }

        public IEnumerable<Productos> GetAll()
        {
            return _DbSet.ToList();
        }

        public async Task<Productos> GetById(int id)
        {
            return await _DbSet.FirstAsync(x => x.Id_Producto == id);
        }

        public async Task<Productos> Create(Productos entity)
        {
            Productos producto = new Productos()
            {
               
                Nombre = entity.Nombre,
                Descripcion = entity.Descripcion,
                Precio = entity.Precio,
                Categoria_id = entity.Categoria_id
            };

            EntityEntry<Productos> result = await _context.AddAsync(producto);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            Productos entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Productos> Update(Productos entity)
        {
            var productos = await GetById(entity.Id_Producto);

            if (productos == null)
            {
                return null;
            }
            productos.Nombre = entity.Nombre;
            productos.Descripcion = entity.Descripcion;
            productos.Precio = entity.Precio;
            productos.Categoria_id = entity.Categoria_id;


            await _context.SaveChangesAsync();
            return productos;
        }
    }
}
