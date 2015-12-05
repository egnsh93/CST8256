using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab10.Exceptions
{
    [Serializable]
    public class CourseExistsException : Exception
    {
        public CourseExistsException() : base() { }

        public CourseExistsException(string message) : base(message) { }
    }
}