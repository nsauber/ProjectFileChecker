using System.IO;

namespace DustyTome.PFC.Core
{
    public class File : IFile
    {
        private Stream _stream;

        public File(string filePath)
        {
            _stream = null;

            FilePath = filePath;
        }

        public string FilePath { get; private set; }
        
        public Stream GetStream()
        {
            if (_stream == null)
            {
                _stream = new FileStream(FilePath, FileMode.Open);
            }

            return _stream;
        }

        public void Dispose()
        {
            if (_stream != null)
            {
                _stream.Dispose();
            }
        }
    }
}
