using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Models
{
    public class CourseOffering
    {
        public Course CourseOffered { get; set; }
        public string Semester { get; set; }
        public List<Student> Students { get; set; }
        public int Year { get; set; }

        public CourseOffering(Course courseOffered, string semester, int year)
        {
            CourseOffered = courseOffered;
            Semester = semester;
            Students = new List<Student>();
            Year = year;
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
            student.RegisteredCourseOfferings.Add(this);
        }

        public void AddStudents(List<Student> students)
        {
            Students.AddRange(students);
            students.ForEach(student => student.RegisteredCourseOfferings.Add(this));
        }

        public List<Student> GetStudents()
        {
            return Students;
        } 
    }
}