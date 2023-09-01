using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class InvalidPositionException : Exception
    {
        public InvalidPositionException()
        {
        }

        public InvalidPositionException(string message)
            : base(message)
        {
        }

        public InvalidPositionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
