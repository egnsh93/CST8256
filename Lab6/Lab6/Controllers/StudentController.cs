using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab6.Factory;
using Lab6.Models;
using Lab6.Services;
using Lab6.Utilities;
using Lab6.ViewModels;

namespace Lab6.Controllers
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
            var offering = _courseService.GetCourseOffering(year, semester, offeringId);

            // Get students in offering and sort based out custom comparer
            var students = _courseService.GetStudents(offering);
            students.Sort(StudentComparer.CustomSort);

            // Update view model with students in course offering
            var viewModel = new StudentViewModel()
            {
                Students = students
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
                var student = studentFactory.CreateStudent(input.Number.ToString(), input.Name, input.Type);

                // Get the course offering
                var offering = _courseService.GetCourseOffering(input.SelectedYear, input.SelectedSemester, input.SelectedCourseId);

                // Add the student
                _courseService.AddStudent(student, offering);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.ToString();
            }

            return RedirectToAction("Add", viewModel);
        }
    }
}