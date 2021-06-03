using ShoeLovers.Repo.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoeLovers.Api.Managers
{
    public interface IShoeSizeManager
    {
        Task<IEnumerable<ShoeSizeEntity>> ListAll();
    }
}