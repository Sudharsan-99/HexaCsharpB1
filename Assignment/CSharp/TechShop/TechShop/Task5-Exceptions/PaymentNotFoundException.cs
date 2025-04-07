using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    class PaymentNotFoundException : Exception
    {
        public PaymentNotFoundException(string message) : base(message) { }
    }
}
