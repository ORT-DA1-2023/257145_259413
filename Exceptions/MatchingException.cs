using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class MatchingException : Exception
    {


        private static string message = "Los campos no son iguales";

        public MatchingException() : base(message)
        {

        }

    }
}
