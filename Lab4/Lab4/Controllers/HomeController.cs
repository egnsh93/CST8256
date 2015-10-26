using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // If user account does not exist, redirect to add user form
            if ((string) HttpContext.Application["name"] == null)
            {
                return RedirectToAction("Add", "User"); 
            }

            // If user exists, but course does not, redirect to add course form
            if ((string)HttpContext.Application["name"] != null && HttpContext.Application["course"] == null)
            {
                return RedirectToAction("Add", "Course");
            }

            // If a user and a course already exist, redirect to add student form
            return RedirectToAction("Add", "Student");
        }
    }
}