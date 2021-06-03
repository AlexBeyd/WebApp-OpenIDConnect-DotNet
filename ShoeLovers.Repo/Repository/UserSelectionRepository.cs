using ShoeLovers.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeLovers.Repo.Repository
{
    public class UserSelectionRepository : BaseRepository<UserSelectionEntity>, IUserSelectionRepository
    {
        public UserSelectionRepository(RepoContext context) : base(context) { }

        public async Task DeleteAsync(Guid userId)
        {
            foreach (var entity in (await Task.Run(() => { return _dbSet.Where(u => u.UserId == userId); })))
                await DeleteAsync(entity);
        }

        public async Task DeleteAsync(UserSelectionEntity entity)
        {
            await Task.Run(() => { _dbSet.Remove(entity); });
        }

        public async Task<IEnumerable<UserSelectionEntity>> ListAsync(Guid userId)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where(e => e.UserId == userId);
            });
        }
    }
}
