using System.Linq;
using System.Web.Mvc;
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
            viewModel.RegisteredCourses = _courseService.GetAllCourses().OrderBy(c => c.Name).ToList();
            return viewModel;
        }

        // GET: Course
        public ActionResult Add() => View(PopulateViewModel(new CourseViewModel()));

        [HttpPost]
        public ActionResult Add(CourseViewModel input)
        {
            // Populate VM
            var viewModel = PopulateViewModel(input);

            // Check for already existing course
            var courseExists = viewModel.RegisteredCourses.Find(c => c.Number == input.Number);

            if (courseExists != null)
                ModelState.AddModelError("Number", "ID already exists");

            // Validate model state
            if (!ModelState.IsValid)
                return View(viewModel);

            // Insert course into database via repository
            _courseService.AddCourse(new Course(input.Number, input.Name, input.WeeklyHours));

            return RedirectToAction("Add");
        }
    }
}