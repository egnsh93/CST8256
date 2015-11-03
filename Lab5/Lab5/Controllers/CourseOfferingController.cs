using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Lab5.Enums;
using Lab5.Repositories;
using Lab5.ViewModels;

namespace Lab5.Controllers
{
    public class CourseOfferingController : Controller
    {
        private readonly ICourseRepository _repository;

        public CourseOfferingController(ICourseRepository repository)
        {
            _repository = repository;
        }

        // GET: CourseOffering
        public ActionResult Add()
        {
            // Get all records from the Course table
            var courses = _repository.GetCourses();

            // Order courses by name
            courses = courses.OrderBy(c => c.Name).ToList();

            // Send the list of courses to the view model
            var offeringVm = new CourseOfferingViewModel()
            {
                Courses = courses,
        };

            return View(offeringVm);
        }
    }
}