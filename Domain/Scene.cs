using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class Scene
    {

        public object name { get; set; }


        public Scene()
        {

        }

        public Scene(string name)
        {
            this.name = name;


        }





        public bool VerifyName(string name)
        {


            if (name.Length == 0 || !Regex.IsMatch(name, @"^[^\s].*[^\s]$"))
            {
                return false;
            }

            return true;




        }
    }
}
