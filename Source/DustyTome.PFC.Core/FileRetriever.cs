using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class FileRetriever : IFileRetriever
    {
        private readonly IEnumerable<string> _filePaths;

        public FileRetriever(IEnumerable<string> filePaths)
        {
            _filePaths = filePaths;
        }

        public IEnumerable<IFile> GetFiles()
        {
            var files = new List<IFile>();

            foreach (var filePath in _filePaths)
            {
                files.Add(new File(filePath));
            }

            return files;
        }
    }
}
