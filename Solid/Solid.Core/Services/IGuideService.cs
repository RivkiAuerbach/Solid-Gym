using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IGuideService
    {
        IEnumerable<Guide> GetAllGuide();

        Guide GetIdGuide(int id);

        void PostGuide(Guide g);

        void PutGuide(Guide g,int id);

        void RemoveGuide(int id);
    }
}
