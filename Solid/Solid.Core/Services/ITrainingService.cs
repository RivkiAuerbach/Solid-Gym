﻿using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface ITrainingService
    {
        Task<IEnumerable<Training>> GetAllTraining();
        Training GetIdTraining(int id);

        Task<Training> PostTraining(Training t);

        void PutTraining(Training t,int id);

        void RemoveTraining(int id);
    }
}
