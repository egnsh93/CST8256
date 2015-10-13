using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class Course
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        /* Initialize Course number, name and student list */

        public Course(string number, string name)
        {
            Number = number;
            Name = name;
            Students = new List<Student>();
        }

        /* Add a new student to the list */

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
    }
}