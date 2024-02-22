using Microsoft.EntityFrameworkCore;
using Solid.Core.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data.Repositories
{
    public class StudentRepositories : IStudentRepository
    {
        private readonly DataContext _dataContext;
        public StudentRepositories(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Student>> GetListStudentAsync()
        {
            return await _dataContext.StudentList.ToListAsync(); 
        }
        public Student GetIdListStudent(int id)
        {
            var stud = _dataContext.StudentList.Find(id);
            return stud;

        }
        public  async Task<Student> PostListStudentAsync(Student s)
        {
            _dataContext.StudentList.Add(s);
           await _dataContext.SaveChangesAsync();
            return s;
        }
        public void PutListStudent(Student s, int id)
        {
            var stud = _dataContext.StudentList.Find(id);
            stud.Name = s.Name;
            stud.Address = s.Address;
            stud.Id = s.Id;
            stud.Age=s.Age;
            _dataContext.SaveChanges();

        }
        public void DeleteListStudent(int id)
        {
            var stud = _dataContext.StudentList.Find(id);
            _dataContext.StudentList.Remove(stud);
            _dataContext.SaveChanges();
        }

    }
}
