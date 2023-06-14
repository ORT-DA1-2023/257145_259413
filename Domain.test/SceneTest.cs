using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.test
{
	[TestClass]
	public class SceneTest
	{


		[TestMethod]
		public void ReturnsFalseIfNameisVoid()
		{
			string name = "";
			Scene scene = new Scene();
			bool result = scene.VerifyName(name);
			Assert.IsFalse(result);
		}


		[TestMethod]
		public void returnFalseIfHasAnySpace()
		{

			string name = " aa2 ";
			Scene scene = new Scene();
			bool result = scene.VerifyName(name);
			Assert.IsFalse(result);

		}

		[TestMethod]
		public void returnTrueIfDateGreatesThanSecondDate()
		{

			DateTime date = DateTime.Now;
			Scene scene = new Scene();
			bool result = scene.VerifyDate(date);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void ReturnsTrueIfPositionedModelListIsCreated()
		{
			Scene scene = new Scene();
			bool result = scene.VerifyPositionedModels();
			Assert.IsTrue(result);
		}




	}
}
