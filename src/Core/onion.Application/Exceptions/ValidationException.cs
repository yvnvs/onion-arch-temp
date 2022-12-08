﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : this("Validation error occured")
        {

        }

        public ValidationException(String Message) : base(Message)
        {

        }

        public ValidationException(Exception ex) : this(ex.Message)
        {

        }
    }
}
