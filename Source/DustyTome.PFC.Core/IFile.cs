using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DustyTome.PFC.Core
{
    public interface IFile
    {
        string FilePath { get; }

        Stream GetStream();
    }
}
