using Microsoft.EntityFrameworkCore;
using ShoeLovers.Repo.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeLovers.Repo.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(RepoContext context)
        {
            _dbSet =  context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
           return (await _dbSet.AddAsync(entity)).Entity;
        }

        public virtual async Task<IEnumerable<TEntity>> ListAllAsync()
        {
            return (await _dbSet.ToListAsync());
        }
    }
}
