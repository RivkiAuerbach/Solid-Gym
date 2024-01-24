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
        IEnumerable<Guide> GetListGuide();
        Guide GetIdListGuide(int id);
        void PostListGuide(Guide g);
        void PutListGuide(Guide g, int id);
        void DeleteListGuide(int id);
       
    }
}
