﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP
{
    public interface IApplicationStage
    {
        void Handle(LoopContext context);
    }
}
