using ShoeLovers.Repo.Model;

namespace ShoeLovers.Repo.Repository
{
    public class ShoeSizeRepository : BaseRepository<ShoeSizeEntity>
    {
        public ShoeSizeRepository(RepoContext context) : base(context) { }
    }
}
