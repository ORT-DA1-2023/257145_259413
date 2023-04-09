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
        public void ReturnsTrueIfUnique()
        {
            Client client = new Client();
            Material material1 = new Material("mat1", Color.FromArgb(1,2,3));
            Material material2 = new Material("mat1", Color.FromArgb(1, 2, 3));
            client.AddMaterial(material1);
            client.AddMaterial(material2);
            bool result = client.VerifyMaterials();
            Assert.IsTrue(result);
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
    }
}
