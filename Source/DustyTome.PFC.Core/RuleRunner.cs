using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class RuleRunner : IRuleRunner
    {
        private readonly IFileRetriever _fileRetriever;
        private readonly IRuleRetriever _ruleRetriever;

        public RuleRunner(IFileRetriever fileRetriever, IRuleRetriever ruleRetriever)
        {
            _fileRetriever = fileRetriever;
            _ruleRetriever = ruleRetriever;
        }

        public IEnumerable<IResult> Run()
        {
            var results = new List<IResult>();

            var files = _fileRetriever.GetFiles();
            var rules = _ruleRetriever.GetRules();

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
