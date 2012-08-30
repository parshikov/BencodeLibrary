using System;
using BencodeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BencodeLibrary_Test
{
    [TestClass]
    public class TestBString
    {
        [TestMethod]
        public void BStringCompare()
        {
            for (char a = 'A'; a < 'Z'; a++)
            {
                for (char b = 'A'; b < 'Z'; b++)
                {
                    string strA = a.ToString();
                    string strB = b.ToString();

                    BString bStrA = new BString(strA);
                    BString bStrB = new BString(strB);

                    Assert.AreEqual(strA.CompareTo(strB), bStrA.CompareTo(bStrB));
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Missing null exception", AllowDerivedTypes = false)]
        public void BStringCompareNull()
        {
            BString a = new BString("");
            BString other = null;

            int result = a.CompareTo(other);
        }

        [TestMethod]
        public void BStringHashcode()
        {
            BString a = new BString("testHashCode");

            Assert.AreEqual("testHashCode".GetHashCode(), a.GetHashCode());
        }
    }
}
