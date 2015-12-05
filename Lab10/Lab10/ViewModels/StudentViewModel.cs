using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10.ViewModels
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "Required"), DisplayName("Course Offering")]
        public string SelectedOffering { get; set; }

        [Required(ErrorMessage = "Required"), DisplayName("Student Number")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Required"), DisplayName("Student Name")]
        public string Name { get; set; }

        public string Type { get; set; }

        public string SelectedSemester { get; set; }

        public int SelectedYear { get; set; }

        public List<CourseOffering> CourseOfferings { get; set; }
        public List<Student> Students { get; set; }
    }
}