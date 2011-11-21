using System.Collections.Generic;

namespace DustyTome.PFC.Core
{
    public interface IFileRetriever
    {
        IEnumerable<IFile> GetFiles();
    }
}
