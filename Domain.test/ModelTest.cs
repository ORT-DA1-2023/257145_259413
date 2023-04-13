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
            Model model = new Model();
            bool result = model.VerifyName(name);
            Assert.IsFalse(result);
        }





    }
}
