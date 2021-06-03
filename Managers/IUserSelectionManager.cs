using ShoeLovers.Repo.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeLovers.Api.Managers
{
    public interface IUserSelectionManager
    {
        Task AddAsync(UserSelectionEntity entity);
        Task AddRangeAsync(IEnumerable<UserSelectionEntity> entitiesList);
        Task<IEnumerable<UserSelectionEntity>> ListAsync(Guid userId);
        Task DeleteAsync(Guid userId);
        Task PersistRangeExactAsync(IEnumerable<UserSelectionEntity> entitiesList);

    }
}
