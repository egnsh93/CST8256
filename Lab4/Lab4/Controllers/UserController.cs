using System.Web.Mvc;
using Lab4.ViewModels;
using Microsoft.Ajax.Utilities;

namespace Lab4.Controllers
{
    public class UserController : Controller
    {
        /* Display the add username view */
        public ActionResult Add() => View("UserName");

        [HttpPost]
        public ActionResult Add(UserViewModel input)
        {
            // Validate the model
            if (ModelState.IsValid == false) return View("UserName");

            // Store the username in the application state
            HttpContext.Application.Lock();
            HttpContext.Application["user"] = input.Name;
            HttpContext.Application.UnLock();
            
            return RedirectToAction("AddColour");
        }

        /* Display the add colour view */
        public ActionResult AddColour() => View("UserColour");

        [HttpPost]
        public ActionResult AddColour(UserColourViewModel input)
        {
            // Validate the model
            if (ModelState.IsValid == false) return View("UserColour");

            // Redirect to overview page and pass along the user data
            return RedirectToAction("Overview", input);
        }

        /* Display the profile overview */
        public ActionResult Overview(UserColourViewModel input) => View("Overview", new UserColourViewModel
        {
            // Populate the profile view with name and colour
            Name = (string) HttpContext.Application["user"],
            Colour = input.Colour
        });

        public ActionResult Delete()
        {
            // Delete the user from the application state and redirect
            HttpContext.Application.Lock();
            HttpContext.Application["user"] = null;
            HttpContext.Application.UnLock();

            return RedirectToAction("Add");
        }
    }
}