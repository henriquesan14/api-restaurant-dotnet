﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Common
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }
}
