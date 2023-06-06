using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class Material
    {
        public int Id { get; set; }
        public string name { get; set; }

        public Color color { get; set; }

        public double blurred { get; set; }
        public string type { get; set; }
        public Client client { get; set; }
        public int clientId { get; set; }



        public static Material createMaterial( string selectedMaterial, string name, Color color, double valueMetalic)
        {
            switch (selectedMaterial)
            {
                case "Metálico":
                    return new MetalicMaterial(name, color, valueMetalic);
                  
                    break;
                default:
                    return new LambertianoMaterial(name, color);
                    break;
            }


        }

        public Material() 
        {
        
        }
   
        public Material(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }
    
     
        public Material(string name, Color color, double blurred)
        {
            this.name = name;
            this.color = color;
            this.blurred = blurred;
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
         
        public bool VeryfyBlurred(double value)
        {
            if (value >= 0.0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "R: " + color.R + " G: " + color.G + " B: " + color.B;
        }

    }
}
