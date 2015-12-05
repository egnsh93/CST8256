using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10.Factory
{
    public class StudentFactory
    {
        public Student CreateStudent(string number, string name, string type)
        {
            switch (type)
            {
                case "Full Time":
                    return new FulltimeStudent(number, name);
                case "Part Time":
                    return new ParttimeStudent(number, name);
                case "Coop":
                    return new CoopStudent(number, name);
            }
            return null;
        }
    }
}