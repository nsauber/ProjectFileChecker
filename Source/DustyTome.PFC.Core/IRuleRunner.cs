using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public interface IRuleRunner
    {
        IEnumerable<IResult> Run(IEnumerable<IFile> files, IEnumerable<IRule> rules);
    }
}
