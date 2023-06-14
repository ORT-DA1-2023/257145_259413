using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.test
{
	[TestClass]
	public class ModelTest
	{

		[TestMethod]
		public void ReturnsFalseIfNameisVoid()
		{
			string name = "";
			Model model = new Model(name);
			bool result;
			try
			{
				result = model.VerifyName(name);
			}
			catch (InvalidDataException)
			{
				result = false;
			}
			Assert.IsFalse(result);
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void returnFalseIfHasAnySpace()
		{

			string name = " aa2 ";
			Model model = new Model(name);
			bool result;
			try
			{
				result = model.VerifyName(name);
			}
			catch (InvalidDataException)
			{
				result = false;
			}
			Assert.IsFalse(result);

		}



		/*[TestMethod]
        public void returnTrueIfUnique()
        {


            Client client1 = new Client();
            Model model1 = new Model("model1");
            Model model2 = new Model("model1");
            client1.AddModel(model1);
            client1.AddModel(model2);
            bool result = client1.VerifyListModels();
            Assert.IsTrue(result);

        }
        */
		[TestMethod]
		public void getFigure()
		{
			Figure fig = new Figure();
			Model model = new Model("model1");


			model.figure = fig;
			Figure result = model.figure;
			Assert.AreEqual(fig, result);
		}

		[TestMethod]
		public void getMaterial()
		{
			Material mat = new Material();
			Model model = new Model("model1");

			model.material = mat;
			Material result = model.material;
			Assert.AreEqual(mat, result);

		}

		[TestMethod]
		public void constructor()
		{
			string name = "model";
			Figure fig = new Figure();
			Material mat = new Material();
			Model model = new Model(name, fig, mat);
			Assert.AreEqual(name, model.name);
			Assert.AreEqual(fig, model.figure);
			Assert.AreEqual(mat, model.material);


		}



	}
}
