using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;

namespace Lab5.ViewModels
{
    public class CourseOfferingViewModel
    {
        public Course CourseOffered { get; set; }
        public string Semester { get; set; }
        public List<Student> Students { get; set; }
        public int Year { get; set; }
    }
}