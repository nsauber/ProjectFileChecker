using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class HardCodedRuleRetriever : IRuleRetriever
    {
        public IEnumerable<IRule> GetRules()
        {
            var rules = new List<IRule>();

            //rules.Add(new AlwaysSuccessfulRule());
            //rules.Add(new AlwaysFailureRule());
            rules.Add(new UsingMsBuild4Rule());

            return rules;
        }
    }
}
