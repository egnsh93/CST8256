using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Controllers
{
    public class CourseOfferingController : Controller
    {
        // GET: CourseOffering
        public ActionResult Add()
        {
            return View();
        }
    }
}