namespace Interface.Exceptions
{
    public class UsuarioRepetidoException: Exception
    {

        private static string message = "Actor Duplicado";

       public UsuarioRepetidoException(string message) : base(message)
        {
           
        }

    }
}
