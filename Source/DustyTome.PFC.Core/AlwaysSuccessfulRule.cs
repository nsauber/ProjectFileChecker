using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class AlwaysSuccessfulRule : IRule
    {
        public string Identifier
        {
            get { return "TEMP001"; }
        }

        public IEnumerable<IError> Check(IFile file)
        {
            return new List<IError>();
        }
    }
}
