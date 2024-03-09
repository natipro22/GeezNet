using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeezNet.Exceptions;

public class NotAnIntegerArgumentException : Exception
{
    public NotAnIntegerArgumentException(object argument)
        : base($"Not an integer! {argument.GetType()} given.")
    {
    }
}
