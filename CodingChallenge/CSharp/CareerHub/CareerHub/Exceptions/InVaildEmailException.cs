using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerHub.Exceptions
{
    public class InVaildEmailException : Exception
    {
        public InVaildEmailException(string message) : base(message) { }
    }
}
