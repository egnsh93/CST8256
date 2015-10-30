using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Mvc;
using Lab5.ViewModels;

namespace Lab5.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CourseViewModel input)
        {
            // Validate model state
            if (!ModelState.IsValid) return View(input);

            // Define ADO.NET objects
            var insertCourseSql = "INSERT INTO Course (CourseID, CourseTitle, HoursPerWeek) VALUES (@courseID, @courseTitle, @courseHours)";

            // Define connection objects
            var connectionString = WebConfigurationManager.ConnectionStrings["StudentRegistration"].ConnectionString;
            var connection = new SqlConnection(connectionString);
        
            var sqlCommand = new SqlCommand(insertCourseSql, connection);

            // Add course parameters
            sqlCommand.Parameters.AddWithValue("@courseID", input.Number);
            sqlCommand.Parameters.AddWithValue("@courseTitle", input.Name);
            sqlCommand.Parameters.AddWithValue("@courseHours", input.WeeklyHours);

            // Check for connection string
            if (connectionString == null) return RedirectToAction("Add", input);

            try
            {
                connection.Open();
                var added = sqlCommand.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return RedirectToAction("Add", input);
        }
    }
}