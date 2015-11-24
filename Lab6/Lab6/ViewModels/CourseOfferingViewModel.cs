using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab6.Enums;
using Lab6.Models;

namespace Lab6.ViewModels
{
    public class CourseOfferingViewModel
    {
        [Required(ErrorMessage = "Required"), DisplayName("Course")]
        public string SelectedCourseId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Required")]
        public Semester Semester { get; set; }

        [Required(ErrorMessage = "Required"), DisplayName("Year")]
        public int SelectedYear { get; set; }

        public string Description { get; set; }

        public List<Course> Courses { get; set; }
        public List<CourseOffering> CourseOfferings { get; set; } 
        public IEnumerable<SelectListItem> Years { get; set; }
    }
}