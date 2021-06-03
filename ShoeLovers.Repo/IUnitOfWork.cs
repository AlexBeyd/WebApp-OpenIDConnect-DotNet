using ShoeLovers.Repo.Model;
using ShoeLovers.Repo.Repository;

namespace ShoeLovers.Repo
{
    public interface IUnitOfWork
    {
        public IUserSelectionRepository UserSelectionRepository { get; }
        public IRepository<ShoeSizeEntity> ShoeSizeRepository { get; }

        void Complete();
    }
}