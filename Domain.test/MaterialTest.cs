using System.Drawing;

namespace Domain.test
{
	[TestClass]
	public class MaterialTest
	{
		[TestMethod]
		public void returnFalseIfNameisVoid()
		{
			string name = "";
			Material material = new Material();
			bool result = material.VerifyName(name);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ReturnFalseIfHasAnySpace()
		{
			string name = " aa2 ";
			Material material = new Material();
			bool result = material.VerifyName(name);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ReturnsFalseIfColorCodeUnderZero()
		{
			int red = -5;
			int green = 5;
			int blue = -10;
			Material material = new Material();
			bool result = material.VerifyColor(red, green, blue);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void ReturnsFalseIfColorCodeGreaterThan255()
		{
			int red = 256;
			int blue = 150;
			int green = 255;
			Material material = new Material();
			bool result = material.VerifyColor(red, green, blue);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void constructor()
		{
			string name = "Material";
			Color color1 = Color.Red;
			Material material1 = new Material(name, color1);
			Assert.AreEqual(name, material1.name);
			Assert.AreEqual(color1, material1.color);
		}

		[TestMethod]
		public void constructorTwo()
		{
			string name = "Material";
			Color color1 = Color.Red;
			string type = "type";
			Material material1 = new Material(name, color1);
			Assert.AreEqual(name, material1.name);
			Assert.AreEqual(color1, material1.color);

		}



		[TestMethod]
		public void toString()
		{
			string name = "Material";
			Color color1 = Color.Red;
			Material material1 = new Material(name, color1);
			Assert.AreEqual("R: " + color1.R + " G: " + color1.G + " B: " + color1.B, material1.ToString());

		}




	}
}
