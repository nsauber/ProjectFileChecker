using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class AlwaysFailureRule : IRule
    {
        public IEnumerable<IError> Check(IFile file)
        {
            var errors = new List<IError>();

            errors.Add(new Error { Message = "Bad file!" });

            return errors;
        }
    }
}
