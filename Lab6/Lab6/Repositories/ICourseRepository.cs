using System.Collections.Generic;
using Lab6.Models;

namespace Lab6.Repositories
{
    public interface ICourseRepository
    {
        void InsertCourse(Course course);
        Course GetCourse(string id);
        List<Course> GetCourses();
    }
}