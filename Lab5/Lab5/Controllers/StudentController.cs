using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab5.Factory;
using Lab5.Models;
using Lab5.Services;
using Lab5.Utilities;
using Lab5.ViewModels;

namespace Lab5.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICourseService _courseService;

        public StudentController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // Populate Student View Model
        public StudentViewModel PopulateViewModel(StudentViewModel viewModel)
        {
            viewModel.CourseOfferings = _courseService.GetAllCourseOfferings();
            viewModel.CourseOfferings.Sort(new CourseOfferingComparer());

            return viewModel;
        }

        // GET: Student
        public ActionResult Add() => View(PopulateViewModel(new StudentViewModel()));

        public PartialViewResult GetStudentsInOffering(string offeringId, int year, string semester)
        {
            // Get the selected course offering
            var offering = _courseService.GetCourseOffering(offeringId, year, semester);

            // Update view model with students in course offering
            var viewModel = new StudentViewModel()
            {
                Students = _courseService.GetAllStudentsByOffering(offering)
            };

            return PartialView("_DisplayStudents", viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel input)
        {
            // Populate VM
            var viewModel = PopulateViewModel(input);

            // Validate model state
            if (!ModelState.IsValid) return View(input);

            // Attempt to add the student to the database/course offering
            try
            {
                // Get the created student from the factory
                var studentFactory = new StudentFactory();
                var student = studentFactory.CreateStudent(input.Number, input.Name, input.Type);

                // Get the course offering
                var offering = _courseService.GetCourseOffering(input.SelectedCourseId, input.SelectedYear, input.SelectedSemester);

                // Add the student
                _courseService.AddStudent(student, offering);
                
            }
            catch (Exception)
            {
                TempData["Error"] = "Something went wrong";
            }

            return RedirectToAction("Add", viewModel);
        }
    }
}