﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class NoSuchProductException : Exception
    {
        
            string message;
            public NoSuchProductException()
            {
                message = "The product with the given id is not present";
            }
            public override string Message => message;

        }
}
