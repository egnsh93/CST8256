using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
    }
}