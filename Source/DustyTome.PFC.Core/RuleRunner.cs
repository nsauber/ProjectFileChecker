using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class RuleRunner : IRuleRunner
    {
        public IEnumerable<IResult> Run(IEnumerable<IFile> files, IEnumerable<IRule> rules)
        {
            var results = new List<IResult>();

            foreach (var rule in rules)
            {
                foreach (var file in files)
                {
                    var result = rule.Run(file);
                    results.Add(result);
                }
            }

            return results;
        }
    }
}
