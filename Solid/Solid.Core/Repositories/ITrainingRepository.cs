using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface ITrainingRepository
    {
        Task<IEnumerable<Training>> GetListTrainingAsync();
        Training GetIdListTraining(int id);
        Task<Training> PostListTrainingAsync(Training t);
        void PutListTraining(Training t, int id);
        void DeleteListTraining(int id);
    }
}
