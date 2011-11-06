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

        public IEnumerable<IFileResults> Run()
        {
            var results = new List<IFileResults>();

            var files = _fileRetriever.GetFiles();
            var rules = _ruleRetriever.GetRules();

            foreach (var file in files)
            {
                var fileResults = new FileResults(file);

                foreach (var rule in rules)
                {
                    var errors = rule.Check(file);
                    fileResults.Merge(errors);
                }

                results.Add(fileResults);
            }

            return results;
        }
    }
}
