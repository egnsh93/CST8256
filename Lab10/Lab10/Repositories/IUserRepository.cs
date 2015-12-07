using System;
using System.Collections.Generic;
using Lab10.Models;

namespace Lab10.Repositories
{
    public interface IUserRepository : IDisposable
    {
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);

        List<Employee> GetEmployees();
    }
}