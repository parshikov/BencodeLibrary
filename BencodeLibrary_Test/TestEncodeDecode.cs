using System.IO;
using BencodeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BencodeLibrary_Test
{
    [TestClass]
    public class TestEncodeDecode
    {
        [TestMethod]
        public void TestDecodingAndEncoding()
        {
            string[] torrentFiles = Directory.GetFiles(@"../../../BencodeLibrary_Test/Resources/", "*.torrent");

            Assert.IsTrue(torrentFiles.Length >= 2);        // Must get at least some files

            foreach (string torrentFile in torrentFiles)
            {
                // Decode
                IBencodingType origTorrent = BencodingUtils.DecodeFile(torrentFile);

                // Encode string
                string origTorrentString = File.ReadAllText(torrentFile, BencodingUtils.ExtendedASCIIEncoding);
                string encodedString = BencodingUtils.EncodeString(origTorrent);

                Assert.AreEqual(origTorrentString, encodedString);
                
                // Decode string
                IBencodingType decodedByString = BencodingUtils.Decode(origTorrentString);
                string encodedByString = BencodingUtils.EncodeString(decodedByString);

                Assert.AreEqual(origTorrentString, encodedByString);

                // Encode bytes
                byte[] origTorrentBytes = File.ReadAllBytes(torrentFile);
                byte[] encodedBytes = BencodingUtils.EncodeBytes(origTorrent);

                Assert.IsTrue(origTorrentBytes.SequenceEqual(encodedBytes));
            }
        }
    }
}
