using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Lab6.Models;
using Lab6.Factory;

namespace Lab6.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connectionString;

        public StudentRepository()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["StudentRegistration"].ConnectionString;
        }

        public void InsertStudent(Student student)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "INSERT INTO Student (StudentNum, Name, Type) VALUES (@studentNum, @name, @type)";

                // Insert parameters into the course table
                cmd.Parameters.AddWithValue("@studentNum", student.Number);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@type", student.ToString());

                // Perform the INSERT operation
                cmd.ExecuteNonQuery();
            }
        }

        public void RegisterStudent(Student student, CourseOffering offering)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "INSERT INTO Registration "
                + "(Student_StudentNum, CourseOffering_Course_CourseID, CourseOffering_Year, CourseOffering_Semester) "
                + "VALUES (@studentNum, @courseID, @year, @semester)";

                // Insert parameters into the course table
                cmd.Parameters.AddWithValue("@studentNum", student.Number);
                cmd.Parameters.AddWithValue("@courseID", offering.CourseOffered.Number);
                cmd.Parameters.AddWithValue("@year", offering.Year);
                cmd.Parameters.AddWithValue("@semester", offering.Semester);

                // Perform the INSERT operation
                cmd.ExecuteNonQuery();
            }
        }

        public bool StudentExists(int number)
        {
            var exists = false;

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "SELECT * from Student WHERE StudentNum = @studentNum";

                // Set the course ID
                cmd.Parameters.AddWithValue("@studentNum", number);

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

        public List<Student> GetStudentsByOffering(CourseOffering offering)
        {
            var students = new List<Student>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = conn.CreateCommand())
            {
                // Open a connection
                conn.Open();

                // Build SQL query
                cmd.CommandText = "SELECT s.StudentNum, s.Name, s.Type FROM Student s "
                                  + "JOIN Registration r ON s.StudentNum = r.Student_StudentNum  "
                                  + "WHERE r.CourseOffering_Course_CourseID=@courseID "
                                  + "  AND r.CourseOffering_Year = @year "
                                  + "  AND r.CourseOffering_Semester = @Semester";

                cmd.Parameters.AddWithValue("@courseID", offering.CourseOffered.Number);
                cmd.Parameters.AddWithValue("@year", offering.Year);
                cmd.Parameters.AddWithValue("@Semester", offering.Semester);

                // Create DataReader for storing the returning table into memory
                var dataReader = cmd.ExecuteReader();

                // If records exist
                if (dataReader.HasRows)
                {
                    // Iterate through each record
                    while (dataReader.Read())
                    {
                        // Extract the course fields
                        var number = Convert.ToInt16(dataReader["StudentNum"]);
                        var name = dataReader["Name"].ToString();
                        var type = dataReader["Type"].ToString();

                        // Get the created student from the factory
                        var studentFactory = new StudentFactory();
                        var student = studentFactory.CreateStudent(number, name, type);

                        // Append to the course list
                        students.Add(student);
                    }
                }

                // Close the DataReader
                dataReader.Close();

                // Execute the SELECT operation
                cmd.ExecuteNonQuery();
            }
            return students;
        }
    }
}