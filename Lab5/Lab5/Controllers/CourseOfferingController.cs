using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Lab5.Models;
using Lab5.Repositories;
using Lab5.Services;
using Lab5.Utilities;
using Lab5.ViewModels;

namespace Lab5.Controllers
{
    public class CourseOfferingController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseOfferingController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: CourseOffering
        public ActionResult Add()
        {
            // Get all records from the Course table
            var courses = _courseService.GetAllCourses();

            var offerings = _courseService.GetAllCourseOfferings();

            offerings.Sort(new CourseOfferingComparer());

            // Order courses by name
            courses = courses.OrderBy(c => c.Name).ToList();

            // Send the list of courses to the view model
            var offeringVm = new CourseOfferingViewModel()
            {
                Courses = courses,
                CourseOfferings = offerings,
                Years = Enumerable.Range(DateTime.Now.Year, 4).Select(i => new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                }),
            };

            return View(offeringVm);
        }

        [HttpPost]
        public ActionResult Add(CourseOfferingViewModel input)
        {
            // Rebind course list on error
            input.Courses = _courseService.GetAllCourses().OrderBy(c => c.Name).ToList();
            input.CourseOfferings = _courseService.GetAllCourseOfferings();
            input.Years = Enumerable.Range(DateTime.Now.Year, 4).Select(i => new SelectListItem
            {
                Text = i.ToString(),
                Value = i.ToString()
            });

            // If model is valid, redirect
            if (ModelState.IsValid)
            {
                // Add Course Offering
                var offering = new CourseOffering(_courseService.GetCourseById(input.SelectedCourseId), input.Semester.ToString(), input.SelectedYear);

                _courseService.AddCourseOffering(offering);
                input.CourseOfferings.Add(offering);

                return RedirectToAction("Add", input);
            }

            // Return to view and display errors
            return View(input);
        }
    }
}