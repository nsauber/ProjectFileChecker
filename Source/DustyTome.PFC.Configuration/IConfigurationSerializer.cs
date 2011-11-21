namespace DustyTome.PFC.Configuration
{
    public interface IConfigurationSerializer
    {
        void WriteToFile(Configuration configuration, string filePath);

        Configuration ReadFromFile(string filePath);
    }
}
