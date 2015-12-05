using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab10.Models
{
    public partial class FulltimeStudent
    {
        public FulltimeStudent()
        {
        }

        public FulltimeStudent(string number, string name) : base(number, name)
        {
        }

        public override string ToString() => "Full Time";

        public override double? TuitionPayable() => 1000.0;
    }
}