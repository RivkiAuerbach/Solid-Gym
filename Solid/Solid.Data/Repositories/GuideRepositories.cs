using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class GuideRepositories : IGuideRepository
    {
        private readonly DataContext _dataContext;
        public GuideRepositories(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Guide> GetListGuide()
        {
            return _dataContext.GuideList;
        }
        public Guide GetIdListGuide(int id)
        {
            var guid = _dataContext.GuideList.Find(id);
            return guid;
             
        }
        public void PostListGuide(Guide g)
        {
            _dataContext.GuideList.Add(g);
            _dataContext.SaveChanges();

        }
        public void PutListGuide(Guide g,int id)
        {
            var guid = _dataContext.GuideList.Find(id);
            guid.Name = g.Name;
            guid.Address = g.Address;
            guid.Id = g.Id;
            guid.Seniority=g.Seniority;
            _dataContext.SaveChanges();
        }
        public void DeleteListGuide(int id)
        {
            var guid = _dataContext.GuideList.Find(id);
            _dataContext.GuideList.Remove(guid);
            _dataContext.SaveChanges();
        }

    }    
}
