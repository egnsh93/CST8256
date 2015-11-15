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
                case "full-time":
                    return new FullTimeStudent(number, name);
                case "part-time":
                    return new PartTimeStudent(number, name);
                case "coop":
                    return new CoopStudent(number, name);
            }
            return null;
        }
    }
}