using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab10.Models
{
    public partial class ParttimeStudent
    {
        public ParttimeStudent()
        {
        }

        public ParttimeStudent(string number, string name) : base(number, name)
        {
        }

        public override string ToString() => "Part Time";

        public override double? TuitionPayable() => (CourseOfferings.Sum(courseOffering => courseOffering.Course.HoursPerWeek)) * Course.CourseHourlyFeeRate;
    }
}