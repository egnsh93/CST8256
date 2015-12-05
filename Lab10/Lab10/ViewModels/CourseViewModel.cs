using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10.ViewModels
{
    public class CourseViewModel
    {
        [Required(ErrorMessage = "Required")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [DisplayName("Weekly Hours"), Required(ErrorMessage = "Required")]
        public int? WeeklyHours { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }

        public List<Course> RegisteredCourses { get; set; }
    }
}