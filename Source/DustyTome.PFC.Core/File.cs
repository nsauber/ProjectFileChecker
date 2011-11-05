using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DustyTome.PFC.Core
{
    public class File : IFile
    {
        public File(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; private set; }
        
        public Stream GetStream()
        {
            return new FileStream(FilePath, FileMode.Open);
        }
    }
}
