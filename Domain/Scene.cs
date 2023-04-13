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
        private List<PositionedModel> _positionedModels;

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

        public bool VerifyDate(DateTime date)
        {
            DateTime dateNow = DateTime.Now;

            if (DateTime.Compare(dateNow, date) > 0)
            {

                return true;
            }

            return false;
        }

        public bool VerifyPositionedModels()
        {
            return true;
        }
    }
}

