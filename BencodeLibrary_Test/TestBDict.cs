using System;
using BencodeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BencodeLibrary_Test
{
    [TestClass]
    public class TestBDict
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BDictAddNullKey()
        {
            BDict dict = new BDict();

            dict.Add(null, new BInt(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BDictAddNullValue()
        {
            BDict dict = new BDict();

            dict.Add("a", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BDictSetNullValue()
        {
            BDict dict = new BDict();

            dict.Add("a", new BInt(0));
            dict["a"] = null;
        }

        [TestMethod]
        public void BDictSetValue()
        {
            BDict dict = new BDict();

            dict.Add("a", new BInt(0));
            BInt newInt = new BInt(1);
            dict["a"] = newInt;

            Assert.AreEqual(newInt, dict["a"]);
        }
    }

    [TestClass]
    public class TestBList
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BListAddNullValue()
        {
            BList list = new BList();

            list.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BListSetNullValue()
        {
            BList list = new BList();

            list.Add(new BInt(0));
            list[0] = null;
        }

        [TestMethod]
        public void BListSetValue()
        {
            BList list = new BList();

            list.Add(new BInt(0));
            BInt newInt = new BInt(1);
            list[0] = newInt;

            Assert.AreEqual(newInt, list[0]);
        }
    }
}
