using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class Material
    {
        public string name;
        public Color color;
        public string type;

        public Material() 
        {
        
        }

        public Material(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }

        public Material(string name, Color color, string type)
        {
            this.name = name;
            this.color = color;
            this.type = type;
        }

        public bool VerifyColor(int red, int green, int blue)
        {
            if(red < 0 || green < 0 || blue < 0 || red >255 || green > 255 || blue > 255)
            {
                return false;
            }
            return true;
        }

        public bool VerifyName(string name)
        {
            if(name.Length == 0 || !Regex.IsMatch(name, @"^[^\s].*[^\s]$"))
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return "R: " + color.R + " G: " + color.G + " B: " + color.B;
        }
    }
}
