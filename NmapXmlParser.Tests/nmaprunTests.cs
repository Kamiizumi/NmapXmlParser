using System.IO;
using System.Xml.Serialization;
using Xunit;

namespace NmapXmlParser.Tests
{
    /// <summary>
    /// Tests for <see cref="nmaprun"/>.
    /// </summary>
    public class nmaprunTests
    {
        /// <summary>
        /// Ensures that an Nmap XML output file deserializes and maps the <see cref="nmaprun.args"/> property.
        /// </summary>
        [Fact]
        public void Deserialize_ValidXml_SetsArgs()
        {
            var xmlSerializer = new XmlSerializer(typeof(nmaprun));
            var result = default(nmaprun);

            using (var sampleXmlStream = new StreamReader("Samples/nmap -T4 -oX Results.xml --webxml scanme.nmap.org.xml"))
            {
                result = xmlSerializer.Deserialize(sampleXmlStream) as nmaprun;
            }

            Assert.Equal("nmap -T4 -oX Results.xml --webxml scanme.nmap.org", result.args);
        }
    }
}
