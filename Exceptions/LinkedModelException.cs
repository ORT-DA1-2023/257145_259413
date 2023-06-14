using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class LinkedModelException : Exception
    {


        private static string message = "El modelo seleccionado está siendo usado por una escena existente";

        public LinkedModelException() : base(message)
        {

        }

    }
}
