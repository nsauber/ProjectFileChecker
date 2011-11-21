using System.Collections.Generic;

namespace DustyTome.PFC.Core
{
    public interface IRuleRunner
    {
        IEnumerable<IFileResults> Run();
    }
}
