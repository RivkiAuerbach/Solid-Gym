using Solid.Core.Entities;
using Solid.Core.Repositories;
using Solid.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Service
{
    public class GuideService : IGuideService
    {
        private readonly IGuideRepository _guideRepository;
        public GuideService(IGuideRepository guideRepository)
        {
            _guideRepository = guideRepository;
        }
        public IEnumerable<Guide> GetAllGuide()
        {
           // צריך לכתוב לוגיקה עסקית
                return _guideRepository.GetListGuide();
        }
        public Guide GetIdGuide(int id)
        {
            // צריך לכתוב לוגיקה עסקית
            return _guideRepository.GetIdListGuide(id);
        }
        public void PostGuide(Guide g)
        {
             _guideRepository.PostListGuide(g);
        }
        public void PutGuide(Guide g,int id)
        {
            _guideRepository.PutListGuide(g,id);
        }
        public void RemoveGuide(int id)
        {
             _guideRepository.DeleteListGuide(id);
        }
    }
}
