﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
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
            return (from c in _dbContext.Courses
                orderby c.CourseTitle
                select c).ToList();
        }

        public bool CourseExists(Course course)
        {
            return _dbContext.Courses.Any(c => c.CourseID == course.CourseID);
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