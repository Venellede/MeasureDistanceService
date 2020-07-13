namespace CTeleport.Distance.Api.Exceptions
{
    public class InvalidAirportMetadataException : DistanceServiceException
    {
        public InvalidAirportMetadataException(string message) : base(message) { }
    }
}
