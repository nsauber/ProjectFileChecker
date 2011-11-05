using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class AlwaysSuccessfulRule : IRule
    {
        public IResult Run(IFile file)
        {
            return new Result(new List<string>());
        }
    }
}
