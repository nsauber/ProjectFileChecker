﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DustyTome.PFC.Core
{
    public interface IRule
    {
        IResult Run(IFile file);
    }
}