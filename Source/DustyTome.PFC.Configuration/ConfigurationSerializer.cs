using System.IO;
using System.Xml.Serialization;

namespace DustyTome.PFC.Configuration
{
    public class ConfigurationSerializer : IConfigurationSerializer
    {
        private readonly XmlSerializer _serializer;

        public ConfigurationSerializer()
        {
            _serializer = new XmlSerializer(typeof(Configuration));
        }

        public void WriteToFile(Configuration configuration, string filePath)
        {
            using (TextWriter textWriter = new StreamWriter(filePath))
            {
                _serializer.Serialize(textWriter, configuration);
            }
        }

        public Configuration ReadFromFile(string filePath)
        {
            Configuration configuration;

            using (TextReader textReader = new StreamReader(filePath))
            {
                configuration = (Configuration)_serializer.Deserialize(textReader);
            }

            return configuration;
        }
    }
}
