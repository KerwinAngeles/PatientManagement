

namespace GestorPacientes.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task<Entity> AddAsync(Entity entity);
        Task UpdateAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task<List<Entity>> GetAll();
        Task<Entity> GetById(int id);
        Task<List<Entity>> GetAllWithInclude(List<string> properties);
    }
}
