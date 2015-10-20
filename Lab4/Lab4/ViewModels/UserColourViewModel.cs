using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.ViewModels
{
    public class UserColourViewModel
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Colour { get; set; }
    }
}