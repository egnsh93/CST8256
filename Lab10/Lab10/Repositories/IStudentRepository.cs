using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10.Repositories
{
    public interface IStudentRepository : IDisposable
    {
        List<Student> GetStudents(CourseOffering offering);
        bool StudentExists(CourseOffering offering, string number);
        void InsertStudent(Student student);
        void Save();
    }
}