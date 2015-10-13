using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab3.Models;
using Lab3.ViewModels;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.Application["course"] == null)
                return View("CreateCourse");

            return RedirectToAction("AddStudent");
        }

        public ActionResult CreateCourse()
        {
            return View("CreateCourse");
        }

        [HttpPost]
        public ActionResult CreateCourse(CourseViewModel courseViewModel)
        {
            /* Check if there are errors in the submission */
            if (ModelState.IsValid == false)
            {
                return View("CreateCourse");
            }

            /* Create a new course object with the submitted data and store in the application state */
            HttpContext.Application.Lock();
            HttpContext.Application["course"] = new Course(courseViewModel.Number, courseViewModel.Name);
            HttpContext.Application.UnLock();

            return RedirectToAction("AddStudent");
        }

        public ActionResult AddStudent(StudentCourseViewModel studentCourseViewModel)
        {
            /* Get the course and student information from the application state */
            var course = (Course) HttpContext.Application["course"];

            /* Populate Course model with application data */
            studentCourseViewModel = new StudentCourseViewModel
            {
                CourseViewModel = new CourseViewModel
                {
                    Number = course.Number,
                    Name = course.Name,
                    Students = course.Students
                },
            };

            return View(studentCourseViewModel);
        }

        [HttpPost]
        public ActionResult AddStudent(StudentViewModel studentViewModel)
        {
            /* Get the course data from the application state */
            var course = (Course) HttpContext.Application["course"];

            /* Populate Course and Student model with application data */
            var studentCourseViewModel = new StudentCourseViewModel
            {
                CourseViewModel = new CourseViewModel
                {
                    Number = course.Number,
                    Name = course.Name,
                    Students = course.Students
                },
                StudentViewModel = new StudentViewModel
                {
                    Id = studentViewModel.Id,
                    Name = studentViewModel.Name,
                    Grade = studentViewModel.Grade
                },
            };

            /* Check if there are errors in the submission */
            if (ModelState.IsValid == false)
            {
                return View("AddStudent", studentCourseViewModel);
            }

            /* Initialize a new student with the submitted data */
            var student = new Student
            {
                Id = studentViewModel.Id,
                Name = studentViewModel.Name,
                Grade = studentViewModel.Grade
            };

            /* Add the student to the course */
            course.AddStudent(student);

            return RedirectToAction("AddStudent", studentCourseViewModel);
        }

        [HttpGet]
        public ActionResult SortStudents(StudentCourseViewModel studentCourseViewModel)
        {
            /* Get the course and student information from the application state */
            var course = (Course) HttpContext.Application["course"];
            var sortKey = studentCourseViewModel.SortKey;

            List<Student> sortedStudents;

            /* Set the set order based on the selected radio button */
            switch (sortKey)
            {
                case "id":
                    sortedStudents = course.Students.OrderBy(s => s.Id).ToList();
                    break;
                case "name":
                    sortedStudents = course.Students.OrderBy(s => s.Name).ToList();
                    break;
                case "grade":
                    sortedStudents = course.Students.OrderByDescending(s => s.Grade).ToList();
                    break;
                default:
                    sortedStudents = course.Students.OrderBy(s => s.Id).ToList();
                    break;
            }

            /* Populate Course model with application data */
            studentCourseViewModel = new StudentCourseViewModel
            {
                CourseViewModel = new CourseViewModel
                {
                    Number = course.Number,
                    Name = course.Name,
                    Students = sortedStudents
                },
            };

            return View("AddStudent", studentCourseViewModel);
        }
    }
}