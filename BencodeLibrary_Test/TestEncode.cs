using BencodeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BencodeLibrary_Test
{
    [TestClass]
    public class TestEncode
    {
        [TestMethod]
        public void EncodeInteger()
        {
            BInt testInt = new BInt(5);
            string test = BencodingUtils.EncodeString(testInt);

            Assert.AreEqual("i5e", test);
        }
        [TestMethod]
        public void EncodeString()
        {
            BString testString = new BString("Hello World");
            string test = BencodingUtils.EncodeString(testString);

            Assert.AreEqual("11:Hello World", test);
        }
        [TestMethod]
        public void EncodeDictionary()
        {
            BDict testDict = new BDict();
            BString testString = new BString("Hello World");
            BInt testInt = new BInt(5);

            testDict.Add("a", testString);
            testDict.Add("b", testInt);

            string test = BencodingUtils.EncodeString(testDict);

            Assert.AreEqual("d1:a11:Hello World1:bi5ee", test);
        }
        [TestMethod]
        public void EncodeList()
        {
            BList testList = new BList();
            BString testString = new BString("Hello World");
            BInt testInt = new BInt(5);

            testList.Add(testString);
            testList.Add(testInt);

            string test = BencodingUtils.EncodeString(testList);

            Assert.AreEqual("l11:Hello Worldi5ee", test);
        }
    }
}
