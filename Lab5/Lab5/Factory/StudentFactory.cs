using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;

namespace Lab5.Factory
{
    public class StudentFactory
    {
        public Student CreateStudent(int number, string name, string type)
        {
            switch (type)
            {
                case "Full Time":
                    return new FullTimeStudent(number, name);
                case "Part Time":
                    return new PartTimeStudent(number, name);
                case "Coop":
                    return new CoopStudent(number, name);
            }
            return null;
        }
    }
}