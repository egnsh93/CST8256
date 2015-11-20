using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Lab6.Models;
using Ninject;

namespace Lab6.Repositories
{
    public class CourseRepository : ICourseRepository, IDisposable
    {
        private readonly StudentRegistrationEntities _dbContext;
        private bool _disposed = false;

        public CourseRepository(StudentRegistrationEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public Course GetCourse(string id)
        {
            return _dbContext.Courses.Find(id);
        }

        public List<Course> GetCourses()
        {
            return _dbContext.Courses.ToList();
        }

        public void InsertCourse(Course course)
        {
            _dbContext.Courses.Add(course);
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