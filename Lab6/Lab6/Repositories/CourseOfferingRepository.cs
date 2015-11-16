using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Lab6.Models;

namespace Lab6.Repositories
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

        public CourseOffering GetCourseOffering(string id, int year, string semester)
        {
            CourseOffering offering = null;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "SELECT * from CourseOffering INNER JOIN Course ON CourseOffering.Course_CourseID = Course.CourseID WHERE Course_CourseID = @courseID AND Year = @year AND Semester = @semester";

                // Set the course ID
                cmd.Parameters.AddWithValue("@courseID", id);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@semester", semester);

                // Create DataReader for storing the returning table into memory
                var dataReader = cmd.ExecuteReader();

                // Check if the CourseOffering table has records
                if (dataReader.HasRows)
                {
                    // Iterate through each record
                    while (dataReader.Read())
                    {
                        // Extract the course fields
                        var number = dataReader["CourseID"].ToString();
                        var name = dataReader["CourseTitle"].ToString();
                        var weeklyHours = Convert.ToInt16(dataReader["HoursPerWeek"]);

                        // Build the course object
                        var course = new Course(number, name, weeklyHours);

                        // Build the course offering object
                        offering = new CourseOffering(course, semester, year);
                    }
                }

                // Close the DataReader
                dataReader.Close();

                // Execute the SELECT operation
                cmd.ExecuteNonQuery();
            }
            return offering;
        }

        public CourseOffering GetCourseOfferingById(string id)
        {
            CourseOffering offering = null;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "SELECT * from CourseOffering INNER JOIN Course ON CourseID = Course_CourseID WHERE Course_CourseID = @courseID";

                // Set the course ID
                cmd.Parameters.AddWithValue("@courseID", id);

                // Create DataReader for storing the returning table into memory
                var dataReader = cmd.ExecuteReader();

                // Check if the CourseOffering table has records
                if (dataReader.HasRows)
                {
                    // Iterate through each record
                    while (dataReader.Read())
                    {
                        // Extract the course fields
                        var number = dataReader["CourseID"].ToString();
                        var name = dataReader["CourseTitle"].ToString();
                        var weeklyHours = Convert.ToInt16(dataReader["HoursPerWeek"]);

                        var semester = dataReader["Semester"].ToString();
                        var year = Convert.ToInt16(dataReader["Year"]);

                        // Build the course object
                        var course = new Course(number, name, weeklyHours);

                        // Build the course offering object
                        offering = new CourseOffering(course, semester, year);
                    }
                }

                // Close the DataReader
                dataReader.Close();

                // Execute the SELECT operation
                cmd.ExecuteNonQuery();
            }
            return offering;
        }

        public bool CourseOfferingExists(CourseOffering offering)
        {
            var exists = false;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "SELECT * from CourseOffering WHERE Course_CourseID = @courseID AND Semester = @semester AND Year = @year";

                // Set the course ID
                cmd.Parameters.AddWithValue("@courseID", offering.CourseOffered.Number);
                cmd.Parameters.AddWithValue("@semester", offering.Semester);
                cmd.Parameters.AddWithValue("@year", offering.Year);

                // Create DataReader for storing the returning table into memory
                var dataReader = cmd.ExecuteReader();
                exists = dataReader.HasRows;

                // Close the DataReader
                dataReader.Close();

                // Execute the SELECT operation
                cmd.ExecuteNonQuery();
            }
            return exists;
        }
    }
}