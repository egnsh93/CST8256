using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Lab10.Repositories;
using Lab10.ViewModels;

namespace Lab10.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        // Login
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel login, string returnUrl)
        {
            // Check if a user exists with the email and password
            var userAuthorized = _userRepository.GetEmployees().Any(
                e => 
                e.Email == login.Email && 
                e.Password == login.Password);

            // If the user
            if (userAuthorized)
            {
                FormsAuthentication.RedirectFromLoginPage(login.Email, login.RememberMe);
            }
            else
            {
                ViewBag.Error = "Unable to find an employee with the submitted information";
            }

            return View("Login");
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}