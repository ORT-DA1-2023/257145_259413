using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class Figure
    {


        public string name;
        private float radio;

        public Figure()
        {

        }

        public Figure( string name, float radio)
        {
            this.name = name;
            this.radio = radio;

        }

        public bool VerifyNameFigure(string name)
        {
            if (name.Length == 0 || !Regex.IsMatch(name, @"^[^\s].*[^\s]$"))
            {
                return false;


            }
            return true;
            /*
            if (name.Length==0)
            {
                return false;
            }

            return true;
            */
        }

        public bool VerifyRadiusFigure(float radius)
        {

            if (radius >0 && radius.ToString().Contains("."))
            {
                String radiusLetter = radius.ToString();

                
               for (int i=0; i< radiusLetter.Length-1; i++)
                {
                   if (radiusLetter[i].Equals ("."))
                    {
                        if (char.IsDigit(radiusLetter[i+1]))
                        {
                            return true;
                        }


                    }

                } 

            
            }

            return false;
        }
    }
}
