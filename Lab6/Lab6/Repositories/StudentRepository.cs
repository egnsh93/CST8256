using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Lab6.Models;
using Lab6.Factory;

namespace Lab6.Repositories
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

        public bool StudentExists(string number)
        {
            return _dbContext.Students.Any(s => s.StudentNum == number.ToString());
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