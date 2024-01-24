﻿using Solid.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudent();
        Student GetIdStudent(int id);

        void PostStudent(Student s);

        void PutStudent(Student s,int id);

        void RemoveStudent(int id);
    }
}
