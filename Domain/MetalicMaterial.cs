using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MetalicMaterial:Material
    {

        public MetalicMaterial()
        {
        }

       // public MetalicMaterial(string name, Color color, decimal blurred)
        //{
         //   this.name = name;
           // this.color = color;
            //this.blurred = blurred;
       // }


       public MetalicMaterial(string name,Color color,decimal blurred) : base(name, color, blurred)
        {
            
        }



        public override string ToString()
        {
            return "R: " + color.R + " G: " + color.G + " B: " + color.B;
        }




    }
}
