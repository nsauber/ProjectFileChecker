using System.Xml.Serialization;

namespace DustyTome.PFC.Configuration
{
    public class Rule
    {
        [XmlAttribute]
        public string Identifier { get; set; }

        [XmlAttribute]
        public bool Enabled { get; set; }
    }
}
