using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab6.Models;

namespace Lab6.Repositories
{
    public interface ICourseOfferingRepository
    {
        void InsertCourseOffering(CourseOffering courseOffering);
        CourseOffering GetCourseOfferingById(string id);
        CourseOffering GetCourseOffering(string id, int year, string semester);
        List<CourseOffering> GetCourseOfferings();
        bool CourseOfferingExists(CourseOffering offering);
    }
}