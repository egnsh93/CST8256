using System.Linq;

namespace Lab4.Models
{
    public class CoopStudent : Student
    {
        private const int CoopFee = 300;

        public CoopStudent(int number, string name) : base(number, name)
        {
        }

        public override double TuitionPayable()
            => CoopFee + (RegisteredCourses.Sum(h => h.WeeklyHours))*Course.CourseHourlyFeeRate;
    }
}