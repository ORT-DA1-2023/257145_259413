using Domain;

namespace Interface.BusinessLogic
{
    public class SessionManager
    {
        private static SessionManager _instance;
        private Client _logged { get; set; }

        public Client CurrentUser
        {
            get { return _logged; }
            set { _logged = value; }
        }

        public void ClearCurrentUser()
        {
            _logged = null;
        }

        public bool UserIsLogged()
        {
            return _logged != null;
        }
    }
}
