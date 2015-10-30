using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5.Models
{
    public class CoopStudent : Student
    {
        private const int CoopFee = 300;

        public CoopStudent(int number, string name) : base(number, name) { }

        public override string ToString() => "Coop";

        public override double TuitionPayable() => CoopFee + (RegisteredCourseOfferings.Sum(courseOffering => courseOffering.CourseOffered.WeeklyHours)) * Course.CourseHourlyFeeRate;
    }
}