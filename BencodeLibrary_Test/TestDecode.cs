using System.Text;
using BencodeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BencodeLibrary_Test
{
    [TestClass]
    public class TestDecode
    {
        [TestMethod]
        public void DecodeEmptystring()
        {
            const string testString = "";

            IBencodingType testResult = BencodingUtils.Decode(testString);

            Assert.IsNull(testResult);
        }

        [TestMethod]
        public void DecodeInteger()
        {
            const string testString = "i5e";
            BInt testExpected = new BInt(5);

            IBencodingType testResult = BencodingUtils.Decode(testString);

            Assert.AreEqual(testExpected, testResult);
        }

        [TestMethod]
        public void DecodeString()
        {
            const string testString = "11:Hello World";
            BString testExpected = new BString("Hello World");

            IBencodingType testResult = BencodingUtils.Decode(testString);

            Assert.AreEqual(testExpected, testResult);
        }

        [TestMethod]
        public void DecodeString_NullBytes()
        {
            byte[] test = new byte[255];

            for (int x = 0; x < 255; x++)
            {
                test[x] = (byte)x;
            }

            string testString = BencodingUtils.ExtendedASCIIEncoding.GetString(test);
            
            BString testExpected = new BString(testString);

            testString = testString.Length + ":" + testString;

            IBencodingType testResult = BencodingUtils.Decode(testString);

            Assert.AreEqual(testExpected, testResult);
        }

        [TestMethod]
        public void DecodeDict()
        {
            const string testString = "d1:a11:Hello Worlde";

            BDict testExpected = new BDict();
            testExpected.Add("a", new BString("Hello World"));

            IBencodingType testResult = BencodingUtils.Decode(testString);

            Assert.AreEqual(testExpected, testResult);
        }

        [TestMethod]
        public void DecodeDict_Empty()
        {
            const string testString = "de";

            BDict testExpected = new BDict();

            IBencodingType testResult = BencodingUtils.Decode(testString);

            Assert.AreEqual(testExpected, testResult);
        }

        [TestMethod]
        public void DecodeList()
        {
            const string testString = "l1:a11:Hello Worlde";

            BList testExpected = new BList();
            testExpected.Add(new BString("a"));
            testExpected.Add(new BString("Hello World"));

            IBencodingType testResult = BencodingUtils.Decode(testString);

            Assert.AreEqual(testExpected, testResult);
        }

        [TestMethod]
        public void DecodeList_Empty()
        {
            const string testString = "le";
            BList testExpected = new BList();

            IBencodingType testResult = BencodingUtils.Decode(testString);

            Assert.AreEqual(testExpected, testResult);
        }
    }
}
