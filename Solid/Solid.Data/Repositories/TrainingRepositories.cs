﻿using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class TrainingRepositories : ITrainingRepository
    {
        private readonly DataContext _dataContext;
        public TrainingRepositories(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Training>> GetListTrainingAsync()
        {
            return await _dataContext.TrainingList.Include(u => u.Guide).ToListAsync();
        }
        public Training GetIdListTraining(int id)
        {
            var train = _dataContext.TrainingList.Find(id);
            return train;

        }
        public async Task<Training> PostListTrainingAsync(Training t)
        {
            _dataContext.TrainingList.Add(t);
           await _dataContext.SaveChangesAsync();
            return t;
        }
        public void PutListTraining(Training t, int id)
        {
            var train = _dataContext.TrainingList.Find(id);
            train.Hour=t.Hour;
            train.Student=t.Student;
            train.Day = t.Day;
            train.Id=id;
            train.Title=t.Title;
            _dataContext.SaveChanges();
        }
        public void DeleteListTraining(int id)
        {
            var train = _dataContext.TrainingList.Find(id);
            _dataContext.TrainingList.Remove(train);
            _dataContext.SaveChanges();
        }
    }
}
