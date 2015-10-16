using System;
using System.Linq;

namespace Lab4.Models
{
    public class PartTimeStudent : Student
    {
        public DateTime StartDate { get; set; }

        public PartTimeStudent(int number, string name) : base(number, name)
        {
        }

        public PartTimeStudent(int number, string name, DateTime startDate) : base(number, name)
        {
            StartDate = startDate;
        }

        public override double TuitionPayable() => RegisteredCourses.Sum(h => h.WeeklyHours)*Course.CourseHourlyFeeRate;
    }
}