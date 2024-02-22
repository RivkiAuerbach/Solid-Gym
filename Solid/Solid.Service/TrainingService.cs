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
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public async Task<IEnumerable<Training>> GetAllTraining()
        {
            //צריך לכתוב לוגיקה עסקית
              return await _trainingRepository.GetListTrainingAsync();
        }
        public Training GetIdTraining(int id)
        {
            // צריך לכתוב לוגיקה עסקית
            return _trainingRepository.GetIdListTraining(id);
        }
        public async Task<Training> PostTraining(Training t)
        {
           return await _trainingRepository.PostListTrainingAsync(t);
        }
        public void PutTraining(Training t, int id)
        {
            _trainingRepository.PutListTraining(t, id);
        }
        public void RemoveTraining(int id)
        {
            _trainingRepository.DeleteListTraining(id);
        }
    }
}
