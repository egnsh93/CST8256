using System;
using System.Collections.Generic;
using static System.String;
using Lab5.Enums;

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

        public int CompareTo(CourseOffering other) => other == null ? 1 : Year.CompareTo(other.Year);

        public override string ToString()
        {
            return CourseOffered.Number + " " + CourseOffered.Name + " " + Year + " " + Semester;
        }
    }
}