using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class EmptyUserNameException : Exception
    {


        private static string message = "Los campos no pueden estar vacios";

        public EmptyUserNameException() : base(message)
        {

        }

    }
}
