using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Lab10.Models;
using Lab10.Factory;

namespace Lab10.Repositories
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private readonly StudentRegistrationEntities _dbContext;
        private bool _disposed = false;

        public StudentRepository(StudentRegistrationEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Student> GetStudents(CourseOffering offering)
        {
            return offering.Students.ToList();
        }

        public bool StudentExists(CourseOffering offering, string number)
        {
            return offering.Students.FirstOrDefault(s => s.StudentNum == number) != null;
        }

        public void InsertStudent(Student student)
        {
            _dbContext.Students.Add(student);
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