using BencodeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BencodeLibrary_Test
{
    [TestClass]
    public class TestEquality
    {
        [TestMethod]
        public void EqualityInteger()
        {
            BInt testInt = new BInt(5);
            BInt testInt2 = new BInt(5);

            Assert.AreEqual(testInt, testInt2);
            Assert.IsTrue(testInt.Equals(testInt2.Value));
            Assert.IsTrue(testInt.Equals(testInt));
        }

        [TestMethod]
        public void EqualityNulls()
        {
            object testObjectNull = null;

            BInt testInt = new BInt(5);
            BInt testIntNull = null;

            Assert.IsFalse(testInt.Equals(testIntNull));
            Assert.IsFalse(testInt.Equals(testObjectNull));

            BString testString = new BString("");
            BString testStringNull = null;
            string testStringNull2 = null;

            Assert.IsFalse(testString.Equals(testStringNull));
            Assert.IsFalse(testString.Equals(testStringNull2));
            Assert.IsFalse(testString.Equals(testObjectNull));
        }

        [TestMethod]
        public void EqualityString()
        {
            BString testString = new BString("Hello World");
            BString testString2 = new BString("Hello World");

            Assert.AreEqual(testString, testString2);
            Assert.IsTrue(testString.Equals(testString2.Value));
            Assert.IsTrue(testString.Equals(testString));
        }

        [TestMethod]
        public void EqualityList()
        {
            // Make initial list
            BList testList = new BList();
            BString testString = new BString("Hello World");
            BInt testInt = new BInt(5);

            testList.Add(testString);
            testList.Add(testInt);

            // Make test list
            BList testList2 = new BList();
            BString testString2 = new BString("Hello World");
            BInt testInt2 = new BInt(5);

            testList2.Add(testString2);
            testList2.Add(testInt2);

            // Test equality recursive
            Assert.AreEqual(testList, testList2);

            // Test null list
            BList nullList = null;
            Assert.IsFalse(testList.Equals(nullList));

            // Test different counts
            testList2.Add(new BInt(10));
            Assert.IsFalse(testList.Equals(testList2));

            // Test different values
            testList.Add(new BInt(9));

            Assert.IsFalse(testList.Equals(testList2));
        }

        [TestMethod]
        public void EqualityDict()
        {
            // Make initial dict
            BDict testDict = new BDict();
            BString testString = new BString("Hello World");
            BInt testInt = new BInt(5);

            testDict.Add("a", testString);
            testDict.Add("b", testInt);

            // Make test dict
            BDict testDict2 = new BDict();
            BString testString2 = new BString("Hello World");
            BInt testInt2 = new BInt(5);

            testDict2.Add("a", testString2);
            testDict2.Add("b", testInt2);

            // Test equality recursive
            Assert.AreEqual(testDict, testDict2);

            // Test null dict
            BDict nullDict = null;
            Assert.IsFalse(testDict.Equals(nullDict));

            // Test different counts
            testDict2.Add("c", new BInt(10));
            Assert.IsFalse(testDict.Equals(testDict2));

            // Test different values
            testDict.Add("c", new BInt(9));
            Assert.IsFalse(testDict.Equals(testDict2));

            // Test missing keys
            testDict2.Remove("c");
            testDict2.Add("d", new BInt(9));

            Assert.IsFalse(testDict.Equals(testDict2));
        }
    }
}
