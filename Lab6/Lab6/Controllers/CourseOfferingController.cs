using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Lab6.Exceptions;
using Lab6.Models;
using Lab6.Repositories;
using Lab6.Services;
using Lab6.Utilities;
using Lab6.ViewModels;

namespace Lab6.Controllers
{
    public class CourseOfferingController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseOfferingController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // Populate CourseOffering View Model
        public CourseOfferingViewModel PopulateViewModel(CourseOfferingViewModel viewModel)
        {
            viewModel.Courses = _courseService.GetAllCourses().OrderBy(c => c.Name).ToList();
            viewModel.CourseOfferings = _courseService.GetAllCourseOfferings();
            viewModel.CourseOfferings.Sort(new CourseOfferingComparer());
            viewModel.Years = Enumerable.Range(DateTime.Now.Year, 4).Select(i => new SelectListItem
            {
                Text = i.ToString(),
                Value = i.ToString()
            });

            return viewModel;
        }

        // GET: CourseOffering
        public ActionResult Add() => View(PopulateViewModel(new CourseOfferingViewModel()));

        [HttpPost]
        public ActionResult Add(CourseOfferingViewModel input)
        {
            // Populate VM
            var viewModel = PopulateViewModel(input);

            // Validate model state
            if (!ModelState.IsValid)
                return View(viewModel);

            // Attempt to add the offering
            try
            {
                var offering = new CourseOffering(_courseService.GetCourseById(input.SelectedCourseId), input.Semester.ToString(), input.SelectedYear);
                _courseService.AddCourseOffering(offering);
                input.CourseOfferings.Add(offering);
            }
            catch (CourseOfferingExistsException)
            {
                // If the offering already exists, display error
                TempData["Error"] = "Course offering already exists!";
            }

            return RedirectToAction("Add", input);
        }
    }
}