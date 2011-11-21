using System.Collections.Generic;

namespace DustyTome.PFC.Core
{
    public interface IRule
    {
        string Identifier { get; }

        IEnumerable<IError> Check(IFile file);
    }
}
