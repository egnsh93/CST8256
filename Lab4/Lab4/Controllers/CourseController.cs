using System;
using System.Web.Mvc;
using Lab4.Models;
using Lab4.ViewModels;

namespace Lab4.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Add() => View("AddCourse");

        [HttpPost]
        public ActionResult Add(CourseViewModel input)
        {
            // Validate the model
            if (ModelState.IsValid == false) return View("AddCourse");

            // If everything is OK, create the course and store in application state
            HttpContext.Application.Lock();
            HttpContext.Application["course"] = new Course(input.Number, input.Name, Convert.ToInt16(input.Hours));
            HttpContext.Application.UnLock();

            return RedirectToAction("Add", "Student");
        }
    }
}