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
        public double radius;

        public Figure()
        {

        }

        public Figure( string name, double radius)
        {
            this.name = name;
            this.radius = radius;

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
            return radius.GetType() == typeof(double)? (double)radius >0 : false;
        }
    }
}
