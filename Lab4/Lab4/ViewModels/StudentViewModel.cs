using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.ViewModels
{
    public class StudentViewModel
    {
        [Required(ErrorMessage = "Required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }

        public string Type { get; set; }
    }
}