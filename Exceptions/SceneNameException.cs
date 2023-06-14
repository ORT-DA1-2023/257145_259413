using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class SceneNameException : Exception
    {


        private static string message = "nombre no debe tener espacios (Principio, ni final)";

        public SceneNameException() : base(message)
        {

        }

    }
}
