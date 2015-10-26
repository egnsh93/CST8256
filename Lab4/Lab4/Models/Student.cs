using System;
using System.Collections.Generic;
using static System.String;

namespace Lab4.Models
{
    public abstract class Student : IComparable<Student>
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public List<Course> RegisteredCourses { get; set; }

        protected Student(int number, string name)
        {
            Number = number;
            Name = name;
            RegisteredCourses = new List<Course>();
        }

        // Set default student sorting by name
        public int CompareTo(Student other) => other == null ? 1 : Compare(Name, other.Name, StringComparison.Ordinal);

        public abstract double TuitionPayable();
    }
}