using System;
using System.Collections.Generic;

namespace Rovers.App
{
    public class RoverException : Exception
    {
        public RoverException(string message) : base(message) {  }
    }
}
