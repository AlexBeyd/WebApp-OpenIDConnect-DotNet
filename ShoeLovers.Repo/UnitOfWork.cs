using ShoeLovers.Repo.Model;
using ShoeLovers.Repo.Repository;

namespace ShoeLovers.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        RepoContext _context;
        public UnitOfWork(RepoContext context)
        {
            _context = context;
            UserSelectionRepository = new UserSelectionRepository(context);
           ShoeSizeRepository = new ShoeSizeRepository(context);
        }

        public IUserSelectionRepository UserSelectionRepository { get; }
        public IRepository<ShoeSizeEntity> ShoeSizeRepository { get; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
