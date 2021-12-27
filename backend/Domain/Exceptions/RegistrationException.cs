using System;

namespace Domain.Exceptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException(string message)
            : base(message)
        { }
    }
}
