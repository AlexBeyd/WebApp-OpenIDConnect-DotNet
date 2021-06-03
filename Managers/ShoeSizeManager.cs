using ShoeLovers.Repo;
using ShoeLovers.Repo.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeLovers.Api.Managers
{
    public class ShoeSizeManager : IShoeSizeManager
    {
        IUnitOfWork _uow;
        public ShoeSizeManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ShoeSizeEntity>> ListAll()
        {
            return await _uow.ShoeSizeRepository.ListAllAsync();
        }
    }
}
