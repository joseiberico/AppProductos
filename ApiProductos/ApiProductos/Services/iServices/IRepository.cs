using ApiProductos.Models;

namespace ApiProductos.Repository.iRepository
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        IEnumerable<T> GetAll();
        Task<T>Create(T entity);
        Task<T> Update(T entity);
        Task<bool>Delete(int id);
    }
}
