using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lab3.Models;

namespace Lab3.ViewModels
{
    public class CourseViewModel
    {
        [DisplayName("Number"), Required(ErrorMessage = "Required")]
        public string Number { get; set; }

        [DisplayName("Name"), Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}