using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab10.Exceptions;
using Lab10.Models;
using Lab10.Repositories;
using Lab10.ViewModels;

namespace Lab10.Controllers
{
    [Authorize(Roles = "Department Chair")]
    public class ManageController : Controller
    {
        private readonly IUserRepository _userRepository;

        public ManageController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Manage
        public ActionResult Index() => View();

        public JsonResult Create(ManageViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return Json(new { error = true, message = "There were errors in the submission" });

            try
            {
                // Build the employee object
                var employee = new Employee()
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Password = viewModel.Password
                };

                // Add the employee
                _userRepository.CreateEmployee(employee);

                return Json(new { error = false, message = "Employee successfully created!" });

            }
            catch (EmployeeExistsException)
            {
                // If the employee already exists, display error
                return Json(new { error = true, message = "Employee already exists" });
            }
        }

        [HttpPost]
        public JsonResult Delete(int employeeId)
        {
            var employee = _userRepository.GetEmployees().FirstOrDefault(e => e.Id == employeeId);

            // Delete the employee
            _userRepository.DeleteEmployee(employee);

            return Json(new { error = false, message = "The employee has been deleted" });
        }

        public ActionResult List()
        {
            // Get the employees
            var employees = _userRepository.GetEmployees().OrderBy(e => e.Name).ToList();

            return PartialView("_DisplayEmployees", employees);
        }
    }
}