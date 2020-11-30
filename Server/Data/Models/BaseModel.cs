﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnBlazor.Server.Data.Models
{
    public abstract class BaseModel
    {
        public Guid Uuid { get; set; }

        public BaseModel()
        {
            Uuid = Guid.NewGuid();
        }
    }
}
