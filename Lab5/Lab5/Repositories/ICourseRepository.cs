using System.Collections.Generic;
using Lab5.Models;

namespace Lab5.Repositories
{
    public interface ICourseRepository
    {
        void InsertCourse(Course course);
        Course GetCourse(string id);
        List<Course> GetCourses();
    }
}