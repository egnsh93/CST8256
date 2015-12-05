using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab9.Models
{
    public partial class CoopStudent
    {
        private const int CoopFee = 300;

        public CoopStudent()
        {
        }

        public CoopStudent(string number, string name) : base(number, name) { }

        public override string ToString() => "Coop";

        public override double? TuitionPayable() => CoopFee + (CourseOfferings.Sum(courseOffering => courseOffering.Course.HoursPerWeek)) * Course.CourseHourlyFeeRate;
    }
}