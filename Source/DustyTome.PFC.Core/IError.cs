﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public interface IError
    {
        int LineNumber { get; }

        string Message { get; }
    }
}
