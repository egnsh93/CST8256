using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10.Repositories
{
    public interface ICourseOfferingRepository : IDisposable
    {
        CourseOffering GetCourseOfferingById(string id);
        CourseOffering GetCourseOffering(int year, string semester, string id);
        List<CourseOffering> GetCourseOfferings();
        bool CourseOfferingExists(CourseOffering offering);
        void InsertCourseOffering(CourseOffering courseOffering);
        void InsertStudentIntoCourseOffering(Student student, CourseOffering courseOffering);
        void Save();
    }
}