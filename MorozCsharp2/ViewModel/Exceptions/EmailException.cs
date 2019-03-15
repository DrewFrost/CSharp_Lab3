using System;


namespace MorozCsharp2.ViewModel.Exceptions
{
    class EmailException : Exception
    {
        private string _error;

        public EmailException(string error)
        {
            _error = error;
        }


        public string Error
        {
            get { return _error; }
        }
    }
}
