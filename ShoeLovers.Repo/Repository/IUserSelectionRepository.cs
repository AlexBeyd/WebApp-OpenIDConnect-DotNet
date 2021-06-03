using ShoeLovers.Repo.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeLovers.Repo.Repository
{
    public interface IUserSelectionRepository : IRepository<UserSelectionEntity>
    {
        Task<IEnumerable<UserSelectionEntity>> ListAsync(Guid userId);

        Task DeleteAsync(Guid userId);
        Task DeleteAsync(UserSelectionEntity entity);
    }
}