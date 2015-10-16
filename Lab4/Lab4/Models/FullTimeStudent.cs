using System.Linq;

namespace Lab4.Models
{
    public class FullTimeStudent : Student
    {
        public int Level { get; set; }

        public FullTimeStudent(int number, string name) : base(number, name)
        {
        }

        public FullTimeStudent(int number, string name, int level) : base(number, name)
        {
            Level = level;
        }

        public override double TuitionPayable() => RegisteredCourses.Sum(h => h.WeeklyHours)*Course.CourseHourlyFeeRate;
    }
}