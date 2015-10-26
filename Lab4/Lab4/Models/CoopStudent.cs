using System.Linq;

namespace Lab4.Models
{
    public class CoopStudent : Student
    {
        private const int CoopFee = 300;

        public CoopStudent(int number, string name) : base(number, name) {}

        public override string ToString() => "Coop";

        public override double TuitionPayable() => CoopFee + (RegisteredCourses.Sum(course => course.WeeklyHours)) * Course.CourseHourlyFeeRate;
    }
}