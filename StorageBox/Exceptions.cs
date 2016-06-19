﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageBox.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
