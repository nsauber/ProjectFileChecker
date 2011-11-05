using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DustyTome.PFC.Tests
{
    public class TestHelper
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
