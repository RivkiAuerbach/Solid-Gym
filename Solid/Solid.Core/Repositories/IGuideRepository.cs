using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IGuideRepository
    {
        Task<IEnumerable<Guide>> GetListGuideAsync();
        Guide GetIdListGuide(int id);
        Task<Guide> PostListGuideAsync(Guide g);
        void PutListGuide(Guide g, int id);
        void DeleteListGuide(int id);
       
    }
}
