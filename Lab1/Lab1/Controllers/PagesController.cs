using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class PagesController : Controller
    {
        [HttpGet]
        public ActionResult Step1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Step1(FormCollection formCollection)
        {
            Session["username"] = formCollection["username"];

            return RedirectToAction("Step2");
        }

        [HttpGet]
        public ActionResult Step2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Step2(FormCollection formCollection)
        {
            Session["favColour"] = formCollection["favColour"];

            return RedirectToAction("Step3");
        }

        [HttpGet]
        public ActionResult Step3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Step3(FormCollection formCollection)
        {
            formCollection = null;
            Session.Clear();
            return View();
        }
    }
}