using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Lab5.Models;
using Ninject;

namespace Lab5.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string _connectionString;

        public CourseRepository()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["StudentRegistration"].ConnectionString;
        }

        public void InsertCourse(Course course)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "INSERT INTO Course (CourseID, CourseTitle, HoursPerWeek) VALUES (@courseID, @courseTitle, @courseHours)";

                // Insert parameters into the course table
                cmd.Parameters.AddWithValue("@courseID", course.Number);
                cmd.Parameters.AddWithValue("@courseTitle", course.Name);
                cmd.Parameters.AddWithValue("@courseHours", course.WeeklyHours);

                // Perform the INSERT operation
                cmd.ExecuteNonQuery();
            }
        }

        public Course GetCourse(string id)
        {
            Course course = null;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "SELECT * FROM Course WHERE CourseID = @courseID";

                // Set the course ID
                cmd.Parameters.AddWithValue("@courseID", id);

                // Create DataReader for storing the returning table into memory
                var dataReader = cmd.ExecuteReader();

                // Check if the Course table has records
                if (dataReader.HasRows)
                {
                    // Iterate through each record
                    while (dataReader.Read())
                    {
                        // Extract the course fields
                        var number = dataReader["CourseID"].ToString();
                        var name = dataReader["CourseTitle"].ToString();
                        var weeklyHours = Convert.ToInt16(dataReader["HoursPerWeek"]);

                        // Return the matched course
                        course = new Course(number, name, weeklyHours);
                    }
                }

                // Close the DataReader
                dataReader.Close();

                // Execute the SELECT operation
                cmd.ExecuteNonQuery();
            }
            return course;
        }

        public List<Course> GetCourses()
        {
            var courses = new List<Course>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "SELECT * FROM Course";

                // Create DataReader for storing the returning table into memory
                var dataReader = cmd.ExecuteReader();

                // Check if the Course table has records
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

                        // Append to the course list
                        courses.Add(course);
                    }
                }

                // Close the DataReader
                dataReader.Close();

                // Execute the SELECT operation
                cmd.ExecuteNonQuery();
            }
            return courses;
        }
    }
}