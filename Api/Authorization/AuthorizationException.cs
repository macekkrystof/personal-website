using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PersonalWebsite.Api.Authorization
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException()
        {
        }

        public AuthorizationException(string message) : base(message)
        {
        }

        public AuthorizationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
