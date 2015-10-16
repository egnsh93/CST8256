using System;
using System.Collections.Generic;

namespace Lab4.Models
{
    public abstract class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public List<Course> RegisteredCourses { get; set; }

        protected Student(int number, string name)
        {
            Number = number;
            Name = name;
            RegisteredCourses = new List<Course>();
        }

        public int CompareTo(Student other) => -1;

        public abstract double TuitionPayable();
    }
}