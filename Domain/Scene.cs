using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Scene
    {
        public bool VerifyName(string name)
        {


            if (name.Length == 0)
            {
                return false;
            }

            return true;




        }
    }
}
