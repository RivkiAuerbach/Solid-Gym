
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

        //public DataContext()
        //{
        //    GuideList = new List<Guide>
        //      { new Guide { Id =1, Name = "ruti", Address = "hadasim", Seniority = 2 } };
        //    StudentList = new List<Student>
        //      { new Student { Id =1, Name = "rivki", Address = "Pardo", Age = 19 } };
        //    TrainingList = new List<Training>
        //      { new Training { Id =1, Title = "Yoga", Day = 3, Hour = 6.3
        //       ,Guide=new Guide{ Id =1, Name = "Ruti", Address = "Hadasim", Seniority = 2 }
        //       ,Student=new List<Student> { new Student { Id =2, Name = "Rivki", Address =
        //       "Pardo",Age=19 } } } };

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=sample2_db");
        }

    }
}
