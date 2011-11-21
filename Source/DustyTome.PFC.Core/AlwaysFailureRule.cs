using System.Collections.Generic;

namespace DustyTome.PFC.Core
{
    public class AlwaysFailureRule : IRule
    {
        public string Identifier
        {
            get { return "TEMP002"; }
        }

        public IEnumerable<IError> Check(IFile file)
        {
            var errors = new List<IError>();

            errors.Add(new Error { Message = "Bad file!" });

            return errors;
        }
    }
}
