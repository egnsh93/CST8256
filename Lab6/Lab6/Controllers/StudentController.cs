using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Lab6.Exceptions;
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

        [HttpPost]
        public JsonResult Add(StudentViewModel viewModel)
        {
            // Populate VM
            viewModel = PopulateViewModel(viewModel);

            // Validate model state
            if (!ModelState.IsValid)
                return Json(new { error = true, message = "There were errors in the submission" });

            // Attempt to add the student to the database/course offering
            try
            {
                // Get the created student from the factory
                var studentFactory = new StudentFactory();
                var student = studentFactory.CreateStudent(viewModel.Number.ToString(), viewModel.Name, viewModel.Type);

                // Get the course offering
                var offering = _courseService.GetCourseOffering(viewModel.SelectedYear, viewModel.SelectedSemester, viewModel.SelectedOffering);

                // Add the student
                _courseService.AddStudent(student, offering);
            }
            catch (StudentExistsException)
            {
                return Json(new { error = true, message = "Student already in course offering" });
            }

            return Json(new { error = false, message = "Student successfully added to course offering!" });
        }

        public PartialViewResult List(string courseId, string semester, int year)
        {
            // Get the selected course offering
            var offering = _courseService.GetCourseOffering(year, semester, courseId);

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
    }
}