using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab6.Models;

namespace Lab6.Repositories
{
    public interface IStudentRepository
    {
        void InsertStudent(Student student);
        void RegisterStudent(Student student, CourseOffering offering);
        bool StudentExists(int number);
        List<Student> GetStudentsByOffering(CourseOffering offering);
        
    }
}