using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class FovOutOfBoundException : Exception
    {


        private static string message = "El valor de campo de visión es erróneo";

        public FovOutOfBoundException() : base(message)
        {

        }

    }
}
