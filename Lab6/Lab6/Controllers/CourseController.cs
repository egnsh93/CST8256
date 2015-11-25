using System.Linq;
using System.Web.Mvc;
using Lab6.Exceptions;
using Lab6.Models;
using Lab6.Services;
using Lab6.ViewModels;

namespace Lab6.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // Populate Course View Model
        public CourseViewModel PopulateViewModel(CourseViewModel viewModel)
        {
            viewModel.RegisteredCourses = _courseService.GetAllCourses();
            return viewModel;
        }

        // GET: Course
        public ActionResult Add() => View(PopulateViewModel(new CourseViewModel()));

        [HttpPost]
        public JsonResult Add(CourseViewModel input)
        {
            // Validate model state
            if (!ModelState.IsValid)
                return Json(new { error = true, message = "There were errors in the submission" });

            // Attempt to add the course
            try
            {
                // Build the course object
                var course = new Course()
                {
                    CourseID = input.Number,
                    CourseTitle = input.Name,
                    HoursPerWeek = input.WeeklyHours
                };

                // Add the course
                _courseService.AddCourse(course);

            }
            catch (CourseExistsException)
            {
                // If the course already exists, display error
                return Json(new { error = true, message = "Course already exists" });
            }

            return Json(new { error = false, message = "Course successfully created!" });
        }

        public PartialViewResult List()
        {
            // Get the selected course offerings
            var courses = _courseService.GetAllCourses().OrderBy(m => m.CourseTitle).ToList();

            // Update view model with the list of offerings and selected course description
            var viewModel = new CourseViewModel()
            {
                RegisteredCourses = courses,
            };

            // Return a Json object with the course description and the partial view
            return PartialView("_DisplayCourses", viewModel);
        }
    }
}