using System;
using System.Linq;
using System.Web.Mvc;
using Lab4.Models;
using Lab4.Utilities;
using Lab4.ViewModels;

namespace Lab4.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Add()
        {
            var course = (Course) HttpContext.Application["course"];

            return View("AddStudent", new StudentCourseViewModel
            {
                CourseViewModel = new CourseViewModel
                {
                    Number = course.Number,
                    Name = course.Name,
                    Hours = course.WeeklyHours,
                    Students = course.Students,
                },
            });
        }

        [HttpPost]
        public ActionResult Add(StudentViewModel studentViewModel)
        {
            // Get the course from the application state
            var course = (Course) HttpContext.Application["course"];

            Student student = null;

            // Create a new student with the selected enrollment type
            switch (studentViewModel.Type)
            {
                case "full-time":
                    student = new FullTimeStudent(studentViewModel.Number, studentViewModel.Name);
                    break;
                case "part-time":
                    student = new PartTimeStudent(studentViewModel.Number, studentViewModel.Name);
                    break;
                case "coop":
                    student = new CoopStudent(studentViewModel.Number, studentViewModel.Name);
                    break;
            }

            // Populate the view models
            var studentCourseViewModel = new StudentCourseViewModel {
                CourseViewModel = new CourseViewModel
                {
                    Number = course.Number,
                    Name = course.Name,
                    Hours = course.WeeklyHours,
                    Students = course.Students,
                },
                StudentViewModel = new StudentViewModel
                {
                    Number = studentViewModel.Number,
                    Name = studentViewModel.Name,
                    Type = studentViewModel.Type,
                },
            };

            // Check for duplicate student IDs
            foreach (var s in course.Students.Where(s => s.Number == studentViewModel.Number))
            {
                ModelState.AddModelError("StudentViewModel.Number", "ID already exists");
            }

            // Validate the model
            if (ModelState.IsValid == false) return View("AddStudent", studentCourseViewModel);

            // Add student to the course
            course.AddStudent(student);

            // Sort the list using a custom sorter class
            course.Students.Sort(StudentSort.CustomSort);

            return RedirectToAction("Add", studentCourseViewModel);
        }
    }
}