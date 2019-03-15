﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorozCsharp2.ViewModel.Exceptions
{
    class OldException : Exception
    {
        private string _error;

        public OldException(string error)
        {
            _error = error;
        }


        public string Error
        {
            get { return _error; }
        }
    }
}
