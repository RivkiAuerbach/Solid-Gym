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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudent()
        {
            //צריך לכתוב לוגיקה עסקית
                return await _studentRepository.GetListStudentAsync();
        }
        public Student GetIdStudent(int id)
        {
            // צריך לכתוב לוגיקה עסקית
            return _studentRepository.GetIdListStudent(id);
        }
        public async Task<Student> PostStudent(Student s)
        {
           return await _studentRepository.PostListStudentAsync(s);
        }
        public void PutStudent(Student s, int id)
        {
            _studentRepository.PutListStudent(s, id);
        }
        public void RemoveStudent(int id)
        {
            _studentRepository.DeleteListStudent(id);
        }
    }
}
