using Microsoft.VisualStudio.TestTools.UnitTesting;
using Naamloos;

namespace TightBoolTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestValues()
        {
            TightBool mybool = new TightBool();

            Assert.IsFalse(mybool[0]);
            Assert.IsFalse(mybool[1]);
            Assert.IsFalse(mybool[2]);
            Assert.IsFalse(mybool[3]);
            Assert.IsFalse(mybool[4]);
            Assert.IsFalse(mybool[5]);
            Assert.IsFalse(mybool[6]);
            Assert.IsFalse(mybool[7]);

            mybool[0] = true;

            Assert.IsTrue(mybool[0]);
            Assert.IsFalse(mybool[1]);
            Assert.IsFalse(mybool[2]);
            Assert.IsFalse(mybool[3]);
            Assert.IsFalse(mybool[4]);
            Assert.IsFalse(mybool[5]);
            Assert.IsFalse(mybool[6]);
            Assert.IsFalse(mybool[7]);

            mybool[2] = true;

            Assert.IsTrue(mybool[0]);
            Assert.IsFalse(mybool[1]);
            Assert.IsTrue(mybool[2]);
            Assert.IsFalse(mybool[3]);
            Assert.IsFalse(mybool[4]);
            Assert.IsFalse(mybool[5]);
            Assert.IsFalse(mybool[6]);
            Assert.IsFalse(mybool[7]);

            mybool[0] = false;

            Assert.IsFalse(mybool[0]);
            Assert.IsFalse(mybool[1]);
            Assert.IsTrue(mybool[2]);
            Assert.IsFalse(mybool[3]);
            Assert.IsFalse(mybool[4]);
            Assert.IsFalse(mybool[5]);
            Assert.IsFalse(mybool[6]);
            Assert.IsFalse(mybool[7]);

            LongTightBool myLongBool = new LongTightBool();

            Assert.IsFalse(myLongBool[60]);

            myLongBool[60] = true;

            Assert.IsTrue(myLongBool[60]);
        }

        [TestMethod]
        public void TestToString()
        {
            TightBool mybool = new TightBool();

            mybool[2] = true;

            string expectedstring = "0:False 1:False 2:True 3:False 4:False 5:False 6:False 7:False";

            Assert.AreEqual(expectedstring, mybool.ToString());
        }

        [TestMethod]
        public void TestEquals()
        {
            var tight1 = new TightBool();
            var tight2 = new TightBool();

            tight1[0] = true;

            // Create a new tightbool from another's storage.
            var tight3 = new TightBool(tight1.GetStorage());

            Assert.IsTrue(tight1.Equals(tight3));
            Assert.IsFalse(tight1.Equals(tight2));
        }
    }
}
