using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab10.Exceptions
{
    [Serializable]
    public class EmployeeExistsException : Exception
    {
        public EmployeeExistsException() : base() { }

        public EmployeeExistsException(string message) : base(message) { }
    }
}