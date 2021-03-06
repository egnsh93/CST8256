﻿using System.Collections.Generic;

namespace Lab5.Models
{
    public class Course
    {
        public List<Student> Students { get; }

        public static double CourseHourlyFeeRate = 80.0;
        public string Number { get; }
        public string Name { get; }
        public int WeeklyHours { get; }

        public Course(string number, string name, int weeklyHours)
        {
            Number = number;
            Name = name;
            WeeklyHours = weeklyHours;
            Students = new List<Student>();
        }

        public override string ToString()
        {
            return Number + " " + Name;
        }
    }
}