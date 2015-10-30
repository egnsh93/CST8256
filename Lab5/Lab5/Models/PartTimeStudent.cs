using System.Linq;

namespace Lab5.Models
{
    public class PartTimeStudent : Student
    {
        public PartTimeStudent(int number, string name) : base(number, name)
        {
        }

        public override string ToString() => "Part Time";

        public override double TuitionPayable() => (RegisteredCourseOfferings.Sum(courseOffering => courseOffering.CourseOffered.WeeklyHours)) * Course.CourseHourlyFeeRate;
    }
}