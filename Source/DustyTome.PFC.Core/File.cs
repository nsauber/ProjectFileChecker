using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class File : IFile
    {
        public File(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; private set; }
    }
}
