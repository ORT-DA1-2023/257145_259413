using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.test
{

    [TestClass]
    public class FigureTest
    {
        [TestMethod]
        public void returnFalseIfNameisVoid()
        {
            string name = "";
            Figure figure = new Figure();
            bool result = figure.VerifyNameFigure(name);
            Assert.IsFalse(result);


        }

        [TestMethod]
        public void returnFalseIfHasAnySpace()
        {

            string name = " aa2 ";
            Figure figure = new Figure();
            bool result = figure.VerifyNameFigure(name);
            Assert.IsFalse(result);

        }


        [TestMethod]
        public void returnFalseIsNotGreatherThanMoreZero() {

            float radius = 0;
            Figure figure = new Figure();
            bool result = figure.VerifyRadiusFigure(radius);
            Assert.IsFalse(result);

        }


        [TestMethod]
        public void returnFalseIsNotDecimalNumber()
        {
            float number = 4;
            Figure figure = new Figure();
            bool result = figure.VerifyRadiusFigure(number);
            Assert.IsFalse(result);

        }


        [TestMethod]
        public void returnTrueIfUnique()
        {


            Client client1 = new Client();
            Figure figure1 = new Figure("fig1",50);
            Figure figure2 = new Figure("fig1",10);

            client1.AddFigure(figure1);
            client1.AddFigure(figure2);
            bool result = client1.VerifyListFigures();
            Assert.IsTrue(result);

        }




    }
}
