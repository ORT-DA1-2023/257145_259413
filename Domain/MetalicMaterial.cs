using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class MetalicMaterial : Material
	{

		public MetalicMaterial()
		{
		}



		public MetalicMaterial(string name, Color color, double blurred) : base(name, color, blurred)
		{
			this.type = "Metallic";
		}



		public override string ToString()
		{
			return "R: " + color.R + " G: " + color.G + " B: " + color.B;
		}




	}
}