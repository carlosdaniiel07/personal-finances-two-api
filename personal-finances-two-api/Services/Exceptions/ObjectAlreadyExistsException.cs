using System;

namespace personal_finances_two_api.Services.Exceptions
{
    public class ObjectAlreadyExistsException : ApplicationException
    {
        public ObjectAlreadyExistsException(string message) : base (message)
        {

        }
    }
}