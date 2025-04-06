﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exceptions
{
    public class InValidDataException : Exception
    {
        public InValidDataException(string message) : base(message) 
        {
            
        }
    }
}
