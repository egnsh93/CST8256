using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Lab10.Exceptions;
using Lab10.Models;
using Lab10.Repositories;
using Lab10.Services;
using Lab10.Utilities;
using Lab10.ViewModels;

namespace Lab10.Controllers
{
    [Authorize(Roles = "Department Chair, Coordinator")]
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
            viewModel.Courses = _courseService.GetAllCourses().OrderBy(c => c.CourseTitle).ToList();
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
        public JsonResult Add(CourseOfferingViewModel viewModel)
        {
            // Populate VM
            viewModel = PopulateViewModel(viewModel);

            // Validate model state
            if (!ModelState.IsValid)
                return Json(new { error = true, message = "There were errors in the submission"});

            // Attempt to add the offering
            try
            {
                var offering = new CourseOffering()
                {
                    Course_CourseID = viewModel.SelectedCourseId,
                    Semester = viewModel.Semester.ToString(),
                    Year = viewModel.SelectedYear
                };

                _courseService.AddCourseOffering(offering);

            }
            catch (CourseOfferingExistsException)
            {
                // If the offering already exists, display error
                return Json(new { error = true, message = "Course offering already exists" });
            }

            return Json(new { error = false, message = "Course offering successfully created!" });
        }

        public JsonResult List(string courseId)
        {
            // Get the selected course offerings
            var offerings = _courseService.GetAllCourseOfferings().Where(o => o.Course_CourseID == courseId).ToList();

            // Update view model with the list of offerings and selected course description
            var viewModel = new CourseOfferingViewModel()
            {
                CourseOfferings = offerings,
                Description = _courseService.GetCourseById(courseId).Description
            };

            // Return a Json object with the course description and the partial view
            return Json(new { description = viewModel.Description, partial = RenderPartialViewToString("_DisplayOfferings", viewModel) }, JsonRequestBehavior.AllowGet);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}