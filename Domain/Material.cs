using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
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
		public Client client { get; set; }



		public static Material createMaterial(string selectedMaterial, string name, Color color, double blurred)
		{
			switch (selectedMaterial)
			{
				case "Metálico":
					return new MetalicMaterial(name, color, blurred);
				default:
					return new LambertianoMaterial(name, color);
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

		public bool VerifyColor(int red, int green, int blue)
		{
			if (red < 0 || green < 0 || blue < 0 || red > 255 || green > 255 || blue > 255)
			{
				return false;
			}
			return true;
		}

		public bool VerifyName(string name)
		{
			if (name.Length == 0 || !Regex.IsMatch(name, @"^[^\s].*[^\s]$"))
			{
				return false;
			}
			return true;
		}

		public bool VerifyBlurred(double value)
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
