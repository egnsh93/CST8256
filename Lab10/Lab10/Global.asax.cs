using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI;
using Lab10.Models;
using Lab10.Repositories;

namespace Lab10
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs args)
        {
            if (User == null || User.Identity.AuthenticationType != "Forms") return;

            using (var dbContext = new StudentRegistrationEntities())
            {

                var id = (FormsIdentity)User.Identity;
                var firstOrDefault = dbContext.Employees.FirstOrDefault(e => e.Email == id.Name);

                if (firstOrDefault == null) return;

                var employeeId = firstOrDefault.Id;

                var employee = (from em in dbContext.Employees
                    where em.Id == employeeId
                    select em).FirstOrDefault();

                if (employee == null) return;
                var roles = new string[employee.Roles.Count];

                var i = 0;

                foreach (var r in employee.Roles)
                {
                    roles[i++] = r.Role1;
                }

                HttpContext.Current.User = new GenericPrincipal(id, roles);
            }
        }
    }
}
