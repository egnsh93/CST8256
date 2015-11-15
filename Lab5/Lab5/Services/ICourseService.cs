using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;

namespace Lab5.Services
{
    public interface ICourseService
    {
        void AddCourse(Course course);
        void AddCourseOffering(CourseOffering offering);
        void AddStudent(Student student, CourseOffering offering);

        Course GetCourseById(string id);
        CourseOffering GetCourseOffering(string id, int year, string semester);
        CourseOffering GetCourseOfferingById(string id);

        List<Course> GetAllCourses();
        List<CourseOffering> GetAllCourseOfferings();
        List<Student> GetAllStudentsByOffering(CourseOffering offering);
    }
}