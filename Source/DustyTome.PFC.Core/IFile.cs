using System;
using System.IO;

namespace DustyTome.PFC.Core
{
    public interface IFile : IDisposable
    {
        string FilePath { get; }

        Stream GetStream();
    }
}
