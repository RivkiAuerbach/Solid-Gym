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
        IEnumerable<Student> GetListStudent();
        Student GetIdListStudent(int id);
        void PostListStudent(Student s);
        void PutListStudent(Student s, int id);
        void DeleteListStudent(int id);
    }
}
