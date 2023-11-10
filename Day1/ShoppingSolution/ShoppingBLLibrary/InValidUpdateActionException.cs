﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class InValidUpdateActionException : Exception
    {
        string message;
        public InValidUpdateActionException()
        {
            message = "The action you have specified is not valid";
        }
        public override string Message => message;
    }
}
