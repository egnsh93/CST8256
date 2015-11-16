using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6.Exceptions
{
    [Serializable]
    public class StudentExistsException : Exception
    {
        public StudentExistsException() : base() { }

        public StudentExistsException(string message) : base(message) { }
    }
}