using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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




    }
}
