using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public interface IResult
    {
        bool HasErrors { get; }

        IEnumerable<string> GetErrorMessages();
    }
}
