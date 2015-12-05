using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab10.Models
{
    public partial class Course
    {
        public List<Student> Students { get; }

        public static double CourseHourlyFeeRate = 80.0;

        public override string ToString()
        {
            return CourseID + " " + CourseTitle;
        }
    }
}