using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Lab5.Models;

namespace Lab5.ViewModels
{
    public class CourseOfferingViewModel
    {
        [DisplayName("Course")]
        public string SelectedCourseId { get; set; }

        [DisplayName("Semester")]
        public string SelectedSemester { get; set; }

        public List<Course> Courses { get; set; }

    }
}