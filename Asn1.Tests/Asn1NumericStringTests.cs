using System.IO;
using NUnit.Framework;

namespace Asn1.Tests {
    [TestFixture]
    [TestOf(typeof(Asn1ObjectIdentifier))]
    public class Asn1NumericStringTests: BaseTest {

        private static readonly byte[] _etalon = { 0x12, 0x0f, 0x33, 0x30, 0x34, 0x37, 0x34, 0x31, 0x37, 0x30, 0x34, 0x37, 0x30, 0x30, 0x31, 0x32, 0x39 };

        [Test]
        public void ReadTest() {
            var node = Asn1Node.ReadNode(new MemoryStream(_etalon));
            var typed = node as Asn1NumericString;
            Assert.NotNull(typed);
            Assert.AreEqual("304741704700129", typed.Value);
        }

        [Test]
        public void WriteTest() {
            var node = new Asn1NumericString { Value = "304741704700129" };
            var data = node.GetBytes();
            AreEqual(_etalon, data);
        }
    }
}