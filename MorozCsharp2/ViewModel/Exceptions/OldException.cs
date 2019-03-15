using System;

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
