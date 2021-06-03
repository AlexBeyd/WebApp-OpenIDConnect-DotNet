using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeLovers.Repo.Repository
{
    public interface IRepository<TEntity> 
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> ListAllAsync();
    }
}