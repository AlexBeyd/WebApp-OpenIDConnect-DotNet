using ShoeLovers.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_OpenIDConnect_DotNet.Models;

namespace WebApp_OpenIDConnect_DotNet.Mappers
{
    public class ShoeSizeMapper
    {
        public ShoeSizeView ToView(ShoeSizeEntity entity)
        {
            return new ShoeSizeView
            {
                Id = entity.Id,
                Size = entity.Size.ToString(),
                IsSelected = false
            };
        }
    }
}
