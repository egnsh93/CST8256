using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lab5.Models;

namespace Lab5.ViewModels
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "Required")]
        public List<CourseOffering> RegisteredCourseOfferings { get; set; }

        [Range(1, int.MaxValue), Required(ErrorMessage = "Required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        public string Type { get; set; }
    }
}