using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;
using Lab5.Models;
using Lab5.Repositories;
using Lab5.ViewModels;
using Ninject;
using Ninject.Extensions.ContextPreservation;

namespace Lab5.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _repository;

        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        // GET: Course
        public ActionResult Add()
        {
            // Get all records from the Course table
            var courses = _repository.GetCourses();

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
            // Get all records from the Course table
            var courses = _repository.GetCourses();

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
            _repository.InsertCourse(course);

            return RedirectToAction("Add");
        }
    }
}