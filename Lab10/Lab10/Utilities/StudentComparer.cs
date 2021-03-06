﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab10.Models;

namespace Lab10.Utilities
{
    public static class StudentComparer
    {
        public static int CustomSort(Student a, Student b)
        {
            // If the students have different names, sort alphabetically
            if (a.Name.Equals(b.Name) == false) return a.CompareTo(b);

            // If the students have the same name
            if (a.Name.Equals(b.Name))
            {
                // If students have the same type
                return a.ToString().Equals(b.ToString())
                    // Sort by student number
                    ? string.Compare(a.StudentNum, b.StudentNum, StringComparison.Ordinal)
                    // Sort by student type
                    : GetStudentTypeValue(a.GetType()).CompareTo(GetStudentTypeValue(b.GetType()));
            }

            return -1;
        }

        public static int GetStudentTypeValue(Type studentType)
        {
            if (studentType == typeof (FulltimeStudent))
                return 1;
            if (studentType == typeof (ParttimeStudent))
                return 2;
            if (studentType == typeof (CoopStudent))
                return 3;
            return -1;
        }
    }
}