using System;

namespace personal_finances_two_api.Services.Exceptions
{
    public class ObjectNotFoundException : ApplicationException
    {
        public ObjectNotFoundException (string message) : base (message)
        {

        }
    }
}