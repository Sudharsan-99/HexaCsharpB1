using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    class DuplicatePaymentException : Exception
    {
        public DuplicatePaymentException(string message) : base(message) { }
    }
}
