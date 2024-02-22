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
        public async Task<IEnumerable<Guide>> GetAllGuide()
        {
           // צריך לכתוב לוגיקה עסקית
                return await _guideRepository.GetListGuideAsync();
        }
        public Guide GetIdGuide(int id)
        {
            // צריך לכתוב לוגיקה עסקית
            return _guideRepository.GetIdListGuide(id);
        }
        public async Task<Guide> PostGuide(Guide g)
        {
           return await _guideRepository.PostListGuideAsync(g);
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
