﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Claro.Foundation.Core.Exceptions
{
    public class InvalidMediatorResponseCodeException : Exception
    {
        public InvalidMediatorResponseCodeException(string invalidMediatorCode)
           : base($"{Constants.InvalidMediatorResponse.InvalidCodeReturned}: {invalidMediatorCode}")
        {
        }
    }
}