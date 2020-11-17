using Microsoft.VisualStudio.TestTools.UnitTesting;
using Naamloos;

namespace TightBoolTests
{
    [TestClass]
    public class Tests
    {
        public TightBool mybool;

        [TestMethod]
        public void TestValues()
        {
            mybool = new TightBool();

            Assert.IsFalse(mybool[0]);
            Assert.IsFalse(mybool[1]);
            Assert.IsFalse(mybool[2]);
            Assert.IsFalse(mybool[3]);

            mybool[0] = true;

            Assert.IsTrue(mybool[0]);
            Assert.IsFalse(mybool[1]);
            Assert.IsFalse(mybool[2]);
            Assert.IsFalse(mybool[3]);

            mybool[2] = true;

            Assert.IsTrue(mybool[0]);
            Assert.IsFalse(mybool[1]);
            Assert.IsTrue(mybool[2]);
            Assert.IsFalse(mybool[3]);

            mybool[0] = false;

            Assert.IsFalse(mybool[0]);
            Assert.IsFalse(mybool[1]);
            Assert.IsTrue(mybool[2]);
            Assert.IsFalse(mybool[3]);
        }

        [TestMethod]
        public void TestToString()
        {
            mybool = new TightBool();

            mybool[2] = true;

            string expectedstring = "0:False,1:False,2:True,3:False";

            Assert.AreEqual(expectedstring, mybool.ToString());
        }

        [TestMethod]
        public void TestEquals()
        {
            var tight1 = new TightBool(false, true, false, false);
            var tight2 = new TightBool(false, true, false, false);
            var tight3 = new TightBool(true, true, false, false);

            Assert.IsTrue(tight1.Equals(tight2));
            Assert.IsFalse(tight1.Equals(tight3));
        }
    }
}
