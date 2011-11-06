using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public class Error : IError
    {
        public int LineNumber { get; set; }

        public string Message { get; set; }
    }
}
