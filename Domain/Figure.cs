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
        public float radio;

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
          
        }

        public bool VerifyRadiusFigure(Object radius)
        {
            return radius.GetType() == typeof(float)? (float)radius >0 : false;
        }
    }
}
