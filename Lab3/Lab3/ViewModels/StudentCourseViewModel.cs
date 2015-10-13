using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.ViewModels
{
    public class StudentCourseViewModel
    {
        public StudentViewModel StudentViewModel { get; set; }
        public CourseViewModel CourseViewModel { get; set; }
        public string SortKey { get; set; }
    }
}