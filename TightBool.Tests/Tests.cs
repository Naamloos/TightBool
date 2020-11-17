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
            Assert.IsFalse(mybool[5]);
            mybool[5] = true;
            Assert.IsTrue(mybool[5]);

            LongTightBool mylongbool = new LongTightBool();
            Assert.IsFalse(mylongbool[60]);
            mylongbool[60] = true;
            Assert.IsTrue(mylongbool[60]);

            ShortTightBool myshortbool = new ShortTightBool();
            Assert.IsFalse(myshortbool[13]);
            myshortbool[13] = true;
            Assert.IsTrue(myshortbool[13]);

            IntTightBool myintbool = new IntTightBool();
            Assert.IsFalse(myintbool[29]);
            myintbool[29] = true;
            Assert.IsTrue(myintbool[29]);
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
