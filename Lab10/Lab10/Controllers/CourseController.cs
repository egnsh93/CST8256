using System.Linq;
using System.Web.Mvc;
using Lab10.Exceptions;
using Lab10.Models;
using Lab10.Services;
using Lab10.ViewModels;

namespace Lab10.Controllers
{
    [Authorize(Roles = "Department Chair, Coordinator")]
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
        public ActionResult Index() => View();

        public JsonResult CreateUpdate(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return Json(new { error = true, message = "There were errors in the submission" });

            var currentCourse = _courseService.GetCourseById(viewModel.Number);

            // If the course does not exist in the db, add
            if (currentCourse == null)
            {
                try
                {
                    // Build the course object
                    var course = new Course()
                    {
                        CourseID = viewModel.Number,
                        CourseTitle = viewModel.Name,
                        HoursPerWeek = viewModel.WeeklyHours,
                        Description = viewModel.Description
                    };

                    // Add the course
                    _courseService.AddCourse(course);

                    return Json(new { error = false, message = "Course successfully created!" });

                }
                catch (CourseExistsException)
                {
                    // If the course already exists, display error
                    return Json(new {error = true, message = "Course already exists"});
                }
            }

            // Otherwise, update the fields
            currentCourse.CourseID = viewModel.Number;
            currentCourse.CourseTitle = viewModel.Name;
            currentCourse.HoursPerWeek = viewModel.WeeklyHours;
            currentCourse.Description = viewModel.Description;

            // Update the course with the changes
            _courseService.EditCourse(currentCourse);

            return Json(new {error = false, message = "The changes have been made!"});

        }

        [HttpPost]
        public JsonResult Delete(string courseId)
        {
            var course = _courseService.GetCourseById(courseId);

            // Delete the course
            _courseService.DeleteCourse(course);

            return Json(new { error = false, message = "The course has been deleted" });
        }

        [HttpPost]
        public JsonResult GetSelected(string courseId)
        {
            var course = _courseService.GetCourseById(courseId);

            return Json(new { id = course.CourseID, name = course.CourseTitle, hours = course.HoursPerWeek, description = course.Description });
        }

        public ActionResult List()
        {
            // Get the selected course offerings
            var courses = _courseService.GetAllCourses().OrderBy(m => m.CourseTitle).ToList();

            return PartialView("_DisplayCourses", courses);
        }
    }
}