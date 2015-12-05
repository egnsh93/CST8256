using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab10.Models
{
    public partial class CourseOffering
    {
        public Course CourseOffered { get; set; }

        public int CompareTo(CourseOffering other) => other == null ? 1 : Year.CompareTo(other.Year);

        public override string ToString()
        {
            return Course_CourseID + " " + Course.CourseTitle + " " + Year + " " + Semester;
        }
    }
}