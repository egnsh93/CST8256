using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lab4.Models;

namespace Lab4.ViewModels
{
    public class CourseViewModel
    {
        [Required(ErrorMessage = "Required")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Hours { get; set; }

        public List<Student> Students { get; set; } 
    }
}