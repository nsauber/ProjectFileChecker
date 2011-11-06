using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public interface IFileResults
    {
        IFile File { get; }

        string FilePath { get; }

        bool HasErrors { get; }

        IEnumerable<IError> GetErrors();
    }
}
