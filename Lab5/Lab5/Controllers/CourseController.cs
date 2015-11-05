using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using Lab5.Models;
using Lab5.Repositories;
using Lab5.Services;
using Lab5.ViewModels;
using Ninject;
using Ninject.Extensions.ContextPreservation;

namespace Lab5.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        public ActionResult Add()
        {
            // Get all records from the Course table
            var courses = _courseService.GetAllCourses();

            // Order courses by name
            courses = courses.OrderBy(c => c.Name).ToList();

            // Send the list of courses to the view model
            var courseViewModel = new CourseViewModel
            {
                RegisteredCourses = courses,
            };

            return View(courseViewModel);
        }

        [HttpPost]
        public ActionResult Add(CourseViewModel input)
        {
            // Populate view model

            // Validate

            // Insert

            // Get all records from the Course table
            var courses = _courseService.GetAllCourses();

            // Send the list of courses to the view model
            var courseViewModel = new CourseViewModel
            {
                RegisteredCourses = courses,
            };

            // Check if the course already exists
            foreach (var c in courses.Where(c => c.Number == input.Number))
            {
                ModelState.AddModelError("Number", "ID already exists");
            }

            // Validate model state
            if (!ModelState.IsValid) return View(courseViewModel);
            
            // Insert course into database via repository
            var course = new Course(input.Number, input.Name, input.WeeklyHours);
            _courseService.AddCourse(course);

            return RedirectToAction("Add");
        }
    }
}