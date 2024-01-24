﻿using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface ITrainingRepository
    {
        IEnumerable<Training> GetListTraining();
        Training GetIdListTraining(int id);
        void PostListTraining(Training t);
        void PutListTraining(Training t, int id);
        void DeleteListTraining(int id);
    }
}
