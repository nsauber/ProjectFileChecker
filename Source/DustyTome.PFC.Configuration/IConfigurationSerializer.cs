using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Configuration
{
    public interface IConfigurationSerializer
    {
        void WriteToFile(Configuration configuration, string filePath);

        Configuration ReadFromFile(string filePath);
    }
}
