using System.Linq;

namespace Lab4.Models
{
    public class FullTimeStudent : Student
    {
        public int Level { get; set; }

        public FullTimeStudent(int number, string name) : base(number, name)
        {
            Level = 1;
        }

        public FullTimeStudent(int number, string name, int level) : base(number, name)
        {
            Level = level;
        }

        public override string ToString() => "Full Time";

        public override double TuitionPayable() => Level == 1 ? 1000.0 : 800.0;
    }
}