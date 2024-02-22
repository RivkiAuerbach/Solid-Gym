using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetListStudentAsync();
        Student GetIdListStudent(int id);
        Task<Student> PostListStudentAsync(Student s);
        void PutListStudent(Student s, int id);
        void DeleteListStudent(int id);
    }
}
