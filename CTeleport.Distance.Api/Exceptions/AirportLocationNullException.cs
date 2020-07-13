namespace CTeleport.Distance.Api.Exceptions
{
    public class AirportLocationNullException : DistanceServiceException
    {
        public AirportLocationNullException(string message) : base(message) { }
    }
}
