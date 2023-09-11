using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Child.Growth.src.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        EntityEntry<TEntity> Add(TEntity entity);
        EntityEntry<TEntity> Update(TEntity entity);
        EntityEntry<TEntity> Remove(long id);
    }
}