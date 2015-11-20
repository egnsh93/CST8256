using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Lab6.Models;

namespace Lab6.Repositories
{
    public class CourseOfferingRepository : ICourseOfferingRepository, IDisposable
    {
        private readonly StudentRegistrationEntities _dbContext;
        private bool _disposed = false;

        public CourseOfferingRepository(StudentRegistrationEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public CourseOffering GetCourseOfferingById(string id)
        {
            return _dbContext.CourseOfferings.Find(id);
        }

        public CourseOffering GetCourseOffering(int year, string semester, string id)
        {
            return _dbContext.CourseOfferings.Find(year, semester, id);
        }

        public List<CourseOffering> GetCourseOfferings()
        {
            return _dbContext.CourseOfferings.ToList();
        }

        public bool CourseOfferingExists(CourseOffering offering)
        {
            var match = _dbContext.CourseOfferings.Any(
                o =>
                    o.Course_CourseID == offering.Course_CourseID &&
                    o.Year == offering.Year &&
                    o.Semester == offering.Semester);
            return match;
        }

        public void InsertCourseOffering(CourseOffering courseOffering)
        {
            _dbContext.CourseOfferings.Add(courseOffering);
        }

        public void InsertStudentIntoCourseOffering(Student student, CourseOffering courseOffering)
        {
            // Get the current student from the offering
            var currentStudent = _dbContext.Students.FirstOrDefault(s => s.StudentNum == student.StudentNum);

            // If student is not registered
            if (currentStudent == null)
            {
                courseOffering.Students.Add(student);
            }
            else
            {
                courseOffering.Students.Add(currentStudent);
            }

            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}