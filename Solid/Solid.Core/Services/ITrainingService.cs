using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface ITrainingService
    {
        IEnumerable<Training> GetAllTraining();
        Training GetIdTraining(int id);

        void PostTraining(Training t);

        void PutTraining(Training t,int id);

        void RemoveTraining(int id);
    }
}
