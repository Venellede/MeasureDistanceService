using System;

namespace CTeleport.Distance.Api.Exceptions
{
    public class InvalidCalculationException : DistanceServiceException
    {
        public InvalidCalculationException(Exception e) : base("Invalid distance calculation", e) { }
    }
}
