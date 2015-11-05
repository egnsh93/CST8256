using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Lab5.Models;

namespace Lab5.Repositories
{
    public class CourseOfferingRepository : ICourseOfferingRepository
    {
        private readonly string _connectionString;

        public CourseOfferingRepository()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["StudentRegistration"].ConnectionString;
        }

        public void InsertCourseOffering(CourseOffering courseOffering)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "INSERT INTO CourseOffering (Year, Semester, Course_CourseID) VALUES (@year, @Semester, @courseID)";

                // Insert parameters into the course offering table
                cmd.Parameters.AddWithValue("@year", courseOffering.Year);
                cmd.Parameters.AddWithValue("@Semester", courseOffering.Semester);
                cmd.Parameters.AddWithValue("@courseID", courseOffering.CourseOffered.Number);

                // Perform the INSERT operation
                cmd.ExecuteNonQuery();
            }
        }

        public List<CourseOffering> GetCourseOfferings()
        {
            var offerings = new List<CourseOffering>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "SELECT * from CourseOffering INNER JOIN Course ON CourseOffering.Course_CourseID = Course.CourseID";

                // Create DataReader for storing the returning table into memory
                var dataReader = cmd.ExecuteReader();

                // Check if the CourseOffering table has records
                if (dataReader.HasRows)
                {
                    // Iterate through each record
                    while (dataReader.Read())
                    {
                        // Extract the course offering fields

                        // Extract the course fields
                        var number = dataReader["CourseID"].ToString();
                        var name = dataReader["CourseTitle"].ToString();
                        var weeklyHours = Convert.ToInt16(dataReader["HoursPerWeek"]);

                        var year = Convert.ToInt16(dataReader["Year"]);
                        var semester = dataReader["Semester"].ToString();
                        var courseId = dataReader["Course_CourseID"].ToString();

                        // Build the course object
                        var course = new Course(number, name, weeklyHours);

                        // Build the course offering object
                        var offering = new CourseOffering(course, semester, year);

                        // Append to the course offering list
                        offerings.Add(offering);
                    }
                }

                // Close the DataReader
                dataReader.Close();

                // Execute the SELECT operation
                cmd.ExecuteNonQuery();
            }
            return offerings;
        }
    }
}