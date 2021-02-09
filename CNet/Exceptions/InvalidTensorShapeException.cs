using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNet.Exceptions
{
    public class InvalidTensorShapeException : Exception
    {
        public InvalidTensorShapeException(string message) : base(message)
        {

        }
    }
}
