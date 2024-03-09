using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeezNet.Exceptions;
public class NotGeezArgumentException : Exception
{
    public NotGeezArgumentException(object argument)
        : base($"Not a geez number! {argument} given.")
    {
    }
}
