using System;
using System.Collections.Generic;
using Lab6.Models;

namespace Lab6.Repositories
{
    public interface ICourseRepository : IDisposable
    {
        Course GetCourse(string id);
        List<Course> GetCourses();
        bool CourseExists(Course course);
        void InsertCourse(Course course);
        void Save();
    }
}