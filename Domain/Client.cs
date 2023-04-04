using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Domain
{
    public class Client
    {
        public string name;
        private string password;

        public Client()
        {
        }

        public Client(string name, string password)
        {
            this.name = name;
            this.password = password;
        }

        public bool VerifyName(string name)
        {
            if (name.Length<3 || name.Length>20 || !Regex.IsMatch(name, @"^\S+$"))
            { 
                return false;
            }
            bool hasNumber = false;
            bool hasLetter = false;
            foreach (char c in name)
            {
                if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }
            }
            return hasNumber && hasLetter;
        }

        public bool VerifyPassword(string password)
        {
            if(password.Length < 5 || password.Length > 25)
            {
                return false;
            }
            bool hasUpperCase = false;
            bool hasNumber = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpperCase = true;
                }
                if (char.IsDigit(c))
                {
                    hasNumber = true;
                }
            }
            return hasNumber && hasUpperCase;
        }
    }
}