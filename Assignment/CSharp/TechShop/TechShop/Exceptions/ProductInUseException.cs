using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    class ProductInUseException : Exception
    {
        public ProductInUseException(string message):base(message) { }
    }
}
