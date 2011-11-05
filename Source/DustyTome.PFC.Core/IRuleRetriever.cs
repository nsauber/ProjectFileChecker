using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public interface IRuleRetriever
    {
        IEnumerable<IRule> GetRules();
    }
}
