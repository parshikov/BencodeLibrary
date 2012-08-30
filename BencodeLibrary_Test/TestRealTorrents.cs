using System.Collections.Generic;
using System.IO;
using BencodeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BencodeLibrary_Test
{
    [TestClass]
    public class TestRealTorrents
    {
        /// <summary>
        /// The Ubuntu 10.04 Release from ThePirateBay.
        /// http://thepiratebay.org/torrent/5520252
        /// </summary>
        [TestMethod]
        public void TestUbuntu1004()
        {
            string filePath = Path.GetFullPath(@"../../../BencodeLibrary_Test/Resources/Ubuntu.torrent");
            Assert.IsTrue(File.Exists(filePath), "Test file missing");

            BDict torrentFile = BencodingUtils.DecodeFile(filePath) as BDict;

            // Check various aspects
            Assert.AreEqual("http://tracker.thepiratebay.org/announce", (torrentFile["announce"] as BString).Value);
            Assert.AreEqual("Torrent downloaded from http://thepiratebay.org", (torrentFile["comment"] as BString).Value);
            Assert.AreEqual(1272557269, (torrentFile["creation date"] as BInt).Value);

            BList announcelist = torrentFile["announce-list"] as BList;
            List<string> trackers = announcelist.OfType<BList>().Select(s => (s.First() as BString).Value).ToList();
            string[] expectedTrackers = new[] { "http://tracker.thepiratebay.org/announce", "udp://tracker.thepiratebay.org:80/announce", "http://torrent.ubuntu.com:6969/announce", "http://ipv6.torrent.ubuntu.com:6969/announce", "udp://tracker.openbittorrent.com:80/announce", "http://tracker.openbittorrent.com/announce" };

            Assert.IsTrue(expectedTrackers.SequenceEqual(trackers));

            BDict infoDict = torrentFile["info"] as BDict;
            Assert.AreEqual(733419520, (infoDict["length"] as BInt).Value);
            Assert.AreEqual(524288, (infoDict["piece length"] as BInt).Value);
            Assert.AreEqual("ubuntu-10.04-desktop-i386.iso", (infoDict["name"] as BString).Value);

            BString pieces = infoDict["pieces"] as BString;
            Assert.AreEqual(27980, pieces.Value.Length);
        }

        /// <summary>
        /// Verify an actual torrents calculated infohash is the same as reported by uTorrent
        /// </summary>
        [TestMethod]
        public void TestUbuntu1004_InfoHash()
        {
            string filePath = Path.GetFullPath(@"../../../BencodeLibrary_Test/Resources/Ubuntu.torrent");
            Assert.IsTrue(File.Exists(filePath), "Test file missing");

            BDict torrentFile = BencodingUtils.DecodeFile(filePath) as BDict;

            // Calculate infohash
            byte[] expected = new byte[] { 0xAF, 0xC0, 0xF0, 0x89, 0xD1, 0xEE, 0xD6, 0xCB, 0x0F, 0x1B, 0x46, 0xA4, 0x93, 0xAC, 0x95, 0x3C, 0x0B, 0xEA, 0x72, 0x79 };

            byte[] infoHash = BencodingUtils.CalculateTorrentInfoHash(torrentFile["info"] as BDict);

            Assert.IsTrue(infoHash.SequenceEqual(expected));
        }

        /// <summary>
        /// Verify an actual torrents calculated infohash is the same as reported by uTorrent
        /// </summary>
        [TestMethod]
        public void TestBacktrakc52_InfoHash()
        {
            string filePath = Path.GetFullPath(@"../../../BencodeLibrary_Test/Resources/BT5R2-KDE-32.torrent");
            Assert.IsTrue(File.Exists(filePath), "Test file missing");

            BDict torrentFile = BencodingUtils.DecodeFile(filePath) as BDict;

            // Calculate infohash
            byte[] expected = new byte[] { 0xC3, 0x90, 0xF5, 0x33, 0xA9, 0x9B, 0xAE, 0xDA, 0x22, 0xAD, 0xE4, 0x49, 0x95, 0x4A, 0x0D, 0x34, 0x83, 0x3C, 0xA7, 0xF5 };

            byte[] infoHash = BencodingUtils.CalculateTorrentInfoHash(torrentFile["info"] as BDict);

            Assert.IsTrue(infoHash.SequenceEqual(expected));
        }

        

    }
}
