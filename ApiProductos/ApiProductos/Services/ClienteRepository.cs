using ApiProductos.Context;
using ApiProductos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiProductos.Repository
{
    public class ClienteRepository : iRepository.IRepository<Cliente>
    {
        private readonly DbSet<Cliente> _DbSet;
        private readonly ProductosDbContext _context;

        public ClienteRepository(ProductosDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Cliente>();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _DbSet.ToList();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _DbSet.FirstAsync(x => x.Id_Cliente == id);
        }

        public async Task<Cliente> Create(Cliente entity)
        {
            Cliente cliente = new Cliente()
            {
                Nombre = entity.Nombre,
                Direccion = entity.Direccion,
                Telefono = entity.Telefono,
            };

            EntityEntry<Cliente> result = await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            Cliente entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Update(Cliente entity)
        {
            var cliente = await GetById(entity.Id_Cliente);

            if (cliente == null) {
                return null;
            }
            cliente.Nombre = entity.Nombre;
            cliente.Direccion = entity.Direccion;
            cliente.Telefono = entity.Telefono;
            

            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
