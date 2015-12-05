using System;
using System.Collections.Generic;
using Lab9.Models;

namespace Lab9.Repositories
{
    public interface ICourseRepository : IDisposable
    {
        Course GetCourse(string id);
        List<Course> GetCourses();
        bool CourseExists(Course course);
        void InsertCourse(Course course);
        void EditCourse(Course course);
        void DeleteCourse(Course course);
        void Save();
    }
}