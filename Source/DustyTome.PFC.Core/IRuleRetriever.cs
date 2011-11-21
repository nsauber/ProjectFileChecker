using System.Collections.Generic;

namespace DustyTome.PFC.Core
{
    public interface IRuleRetriever
    {
        IEnumerable<IRule> GetRules();
    }
}
