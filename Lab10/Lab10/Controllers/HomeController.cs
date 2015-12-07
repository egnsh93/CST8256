using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab10.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}