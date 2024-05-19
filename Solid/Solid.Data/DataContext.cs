
using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solid.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Solid.Data
{

    public class DataContext : DbContext
    {
        public DbSet<Guide> GuideList { get; set; }
        public DbSet<Student> StudentList { get; set; }
        public DbSet<Training> TrainingList { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=Gym_db");
        }

    }
}
