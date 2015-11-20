using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6.Models
{
    public partial class Student
    {
        protected Student(string number, string name)
        {
            StudentNum = number;
            Name = name;
        }

        // Set default student sorting by name
        public int CompareTo(Student other) => other == null ? 1 : string.Compare(Name, other.Name, StringComparison.Ordinal);

        public abstract double? TuitionPayable();
    }
}