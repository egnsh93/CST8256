namespace Lab5.Models
{
    public class FullTimeStudent : Student
    {
        public FullTimeStudent(int number, string name) : base(number, name)
        {
        }

        public override string ToString() => "Full Time";

        public override double TuitionPayable() => 1000.0;
    }
}