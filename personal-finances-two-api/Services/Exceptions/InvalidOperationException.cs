using System;

namespace personal_finances_two_api.Services.Exceptions
{
    public class InvalidOperationException : ApplicationException
    {
        public InvalidOperationException(string message) : base (message)
        {

        }
    }
}