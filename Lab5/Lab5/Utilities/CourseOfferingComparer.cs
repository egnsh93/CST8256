using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;

namespace Lab5.Utilities
{
    public class CourseOfferingComparer : IComparer<CourseOffering>
    {
        public int Compare(CourseOffering a, CourseOffering b)
        {
            // If the offerings have different names, sort by year
            if (a.Year != b.Year) return a.CompareTo(b);

            // If offerings are in the same year
            if (a.Year == b.Year)
            {
                // If offerings are in same year and semester
                return (a.Year == b.Year) && (a.Semester == b.Semester)
                    // Sort by course title
                    ? String.Compare(a.CourseOffered.Name, b.CourseOffered.Name, StringComparison.Ordinal)
                    // Sort by semester
                    : GetSemesterPriority(a.Semester).CompareTo(GetSemesterPriority(b.Semester));
            }

            return -1;
        }

        public static int GetSemesterPriority(string semester)
        {
            switch (semester)
            {
                case "Fall":
                    return 1;
                case "Winter":
                    return 2;
                case "Summer":
                    return 3;
                case "Spring":
                    return 3;
            }
            return -1;
        }
    }
}