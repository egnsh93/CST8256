using System;
using System.Collections.Generic;
using System.Linq;
using Lab10.Models;
using Lab10.Services;

namespace Lab10.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly StudentRegistrationEntities _dbContext;
        private bool _disposed = false;

        public UserRepository(StudentRegistrationEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateEmployee(Employee employee)
        {
            
        }

        public void DeleteEmployee(Employee employee)
        {
            foreach (var emp in _dbContext.Employees.Where(e => e.Id == employee.Id))
            {
                foreach (var employeeRole in emp.Roles.ToList())
                {
                    emp.Roles.Remove(employeeRole);
                }
            }

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }

        public List<Employee> GetEmployees()
        {
            return _dbContext.Employees.ToList();
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