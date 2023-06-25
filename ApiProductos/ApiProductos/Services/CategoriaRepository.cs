using ApiProductos.Context;
using ApiProductos.Models;
using ApiProductos.Repository.iRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Xml.Linq;

namespace ApiProductos.Repository
{
    public class CategoriaRepository : iRepository.IRepository<Categoria>
    {
        private readonly DbSet<Categoria> _DbSet;
        private readonly ProductosDbContext _context;

        public CategoriaRepository(ProductosDbContext context)
        {
            _context = context;
            _DbSet = context.Set<Categoria>();
        }

        public IEnumerable<Categoria> GetAll()
        {
            return _DbSet.ToList();
        }

        public async Task<Categoria> GetById(int id)
        {
            return await _DbSet.FirstAsync(x => x.Id_Categoria == id);
        }

        public async Task<Categoria> Create(Categoria entity)
        {
            Categoria categoria = new Categoria()
            {
                Nombre = entity.Nombre,
                descripcion = entity.descripcion
            };

            EntityEntry<Categoria> result = await _context.Categoria.AddAsync(categoria);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            Categoria entity = await GetById(id);
            if (entity == null)
            {
                return false;
            }

            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Categoria> Update(Categoria entity)
        {
            var categoria = await GetById(entity.Id_Categoria);

            if (categoria == null)
                return null;

            categoria.Nombre = entity.Nombre;
            categoria.descripcion = entity.descripcion;

            await _context.SaveChangesAsync();
            return categoria;
        }
    }
}

    

        

 
    

