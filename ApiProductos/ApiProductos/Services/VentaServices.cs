using ApiProductos.Context;
using ApiProductos.Models;
using ApiProductos.Services.iServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiProductos.Services
{
    public class VentaServices : IRepository<Venta>
    {
        private readonly DbSet<Venta> _DbSet;
        private readonly ProductosDbContext _context;

        public VentaServices(ProductosDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Venta>();
        }

        public async Task<IEnumerable<Venta>> GetAll()
        {
            return await _DbSet.ToListAsync();
        }

        public async Task<Venta> GetById(int id)
        {
            return await _DbSet.FirstAsync(x => x.Id_Venta == id);
        }

        public async Task<Venta> Create(Venta entity)
        {
            Venta venta = new Venta()
            {
                Fecha_venta = entity.Fecha_venta,
                Cliente_id = entity.Cliente_id,
                Usuario_id = entity.Usuario_id
            };

            EntityEntry<Venta> result = await _context.AddAsync(venta);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            Venta entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Venta> Update(Venta entity)
        {
            var ventas = await GetById(entity.Id_Venta);

            if (ventas == null)
            {
                return null;
            }
            ventas.Fecha_venta = entity.Fecha_venta;
            ventas.Cliente_id = entity.Cliente_id;
            ventas.Usuario_id = entity.Usuario_id;


            await _context.SaveChangesAsync();
            return ventas;
        }
    }
}
