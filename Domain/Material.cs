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
        public string name;
        public Color color;
        public decimal blurred;
        public string type;

        

        public static Material createMaterial( string selectedMaterial, string name, Color color, decimal valueMetalic)
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



        //Material mater=Material.create(lambertiano)

        public Material() 
        {
        
        }
   
        public Material(string name, Color color)
        {
            this.name = name;
            this.color = color;
        }
    
     
        public Material(string name, Color color, decimal blurred)
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
         
        public bool VeryfyBlurred(decimal value)
        {
            if (value >= 0.0m)
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
