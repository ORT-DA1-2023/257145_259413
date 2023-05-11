namespace Exceptions
{
    public class DuplicateUserException : Exception
    {

        private static string message = "Cliente Duplicado";

        public DuplicateUserException() : base(message)
        {
            

        }

    }
}