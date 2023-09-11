using Child.Growth.src.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Child.Growth.src.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public EntityEntry<TEntity> Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity);
        }

        public EntityEntry<TEntity> Update(TEntity entity)
        {
            return _context.Set<TEntity>().Update(entity);
        }

        public EntityEntry<TEntity> Remove(long id)
        {
            var entity = GetById(id);
            return _context.Set<TEntity>().Remove(entity);
        }
    }

}