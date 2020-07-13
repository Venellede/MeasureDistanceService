using System;

namespace CTeleport.Distance.Api.Exceptions
{
    public abstract class DistanceServiceException : Exception
    {
        public DistanceServiceException(string message) : base(message) { }
        public DistanceServiceException(string message, Exception e) : base(message, e) { }
    }
}
