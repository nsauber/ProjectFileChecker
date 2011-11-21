using System.Collections;

namespace DustyTome.PFC.Core
{
    public class EnumerableHelper
    {
        public int NumberOfItemsIn(IEnumerable enumerable)
        {
            int count = 0;
            foreach (var item in enumerable)
            {
                count++;
            }
            return count;
        }
    }
}
