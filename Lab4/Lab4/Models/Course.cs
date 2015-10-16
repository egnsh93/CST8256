using System.Collections.Generic;

namespace Lab4.Models
{
    public class Course
    {
        public List<Student> Students { get; set; }

        public static double CourseHourlyFeeRate { get; set; }

        public string CourseName { get; }
        public int CourseNumber { get; }
        public int WeeklyHours { get; }

        public Course(int courseNumber, string courseName, int weeklyHours)
        {
            CourseNumber = courseNumber;
            CourseName = courseName;
            WeeklyHours = weeklyHours;
        }

        public void AddStudent(Student student) => Students.Add(student);

        public List<Student> GetStudents() => Students;
    }
}