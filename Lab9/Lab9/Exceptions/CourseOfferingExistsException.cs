﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab9.Exceptions
{
    [Serializable]
    public class CourseOfferingExistsException : Exception
    {
        public CourseOfferingExistsException() : base() { }

        public CourseOfferingExistsException(string message) : base(message) { }
    }
}