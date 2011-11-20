using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public interface IRule
    {
        string Identifier { get; }

        IEnumerable<IError> Check(IFile file);
    }
}
