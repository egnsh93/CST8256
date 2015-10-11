using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab3.ViewModels
{
    public class StudentViewModel
    {
        [DisplayName("Id"), Required(ErrorMessage = "Required"), Range(1, int.MaxValue, ErrorMessage = "Must be greater than zero")]
        public int Id { get; set; }

        [DisplayName("Name"), Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        [DisplayName("Grade"), Required(ErrorMessage = "Required"), Range(0, 100, ErrorMessage = "Must be between 0 and 100")]
        public int Grade { get; set; }
    }
}