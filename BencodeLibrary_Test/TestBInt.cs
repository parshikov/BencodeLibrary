using System;
using BencodeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BencodeLibrary_Test
{
    [TestClass]
    public class TestBInt
    {
        [TestMethod]
        public void BIntCompare()
        {
            BInt a = new BInt(10);

            BInt b = new BInt(11);
            Assert.AreEqual(-1, a.CompareTo(b));
            Assert.AreEqual(-1, a.CompareTo(b.Value));

            b.Value = 9;
            Assert.AreEqual(1, a.CompareTo(b));
            Assert.AreEqual(1, a.CompareTo(b.Value));

            b.Value = 10;
            Assert.AreEqual(0, a.CompareTo(b));
            Assert.AreEqual(0, a.CompareTo(b.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Missing null exception", AllowDerivedTypes = false)]
        public void BIntCompareNull()
        {
            BInt a = new BInt(10);
            BInt other = null;

            int result = a.CompareTo(other);
        }

        [TestMethod]
        public void BIntHashcode()
        {
            BInt a = new BInt(10);

            Assert.AreEqual((10L).GetHashCode(), a.GetHashCode());
        }
    }
}
