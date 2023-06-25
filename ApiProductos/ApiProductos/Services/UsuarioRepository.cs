using ApiProductos.Context;
using ApiProductos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiProductos.Repository
{
    public class UsuarioRepository : iRepository.IRepository<Usuario>
    {
        private readonly DbSet<Usuario> _DbSet;
        private readonly ProductosDbContext _context;

        public UsuarioRepository (ProductosDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Usuario>();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _DbSet.ToList();
        }

        public async Task<Usuario> GetById(int id)
        {
            return await _DbSet.FirstAsync(x => x.Id_Usuario == id);
        }

        public async Task<Usuario> Create(Usuario entity)
        {
            Usuario usuario = new Usuario()
            {
                Nombre = entity.Nombre,
                Email = entity.Email,
                Contrasena = entity.Contrasena
            };

            EntityEntry<Usuario> result = await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            Usuario entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario> Update(Usuario entity)
        {
            var usuarios = await GetById(entity.Id_Usuario);

            if (usuarios == null)
            {
                return null;
            }
            usuarios.Nombre = entity.Nombre;
            usuarios.Email = entity.Email;
            usuarios.Contrasena = entity.Contrasena;


            await _context.SaveChangesAsync();
            return usuarios;
        }

    }
}
