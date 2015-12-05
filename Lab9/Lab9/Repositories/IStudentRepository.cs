using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab9.Models;

namespace Lab9.Repositories
{
    public interface IStudentRepository : IDisposable
    {
        List<Student> GetStudents(CourseOffering offering);
        bool StudentExists(CourseOffering offering, string number);
        void InsertStudent(Student student);
        void Save();
    }
}