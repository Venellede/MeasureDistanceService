namespace CTeleport.Distance.Api.Exceptions
{
    public class EmptyAirportMetadataException : DistanceServiceException
    {
        public EmptyAirportMetadataException(string message) : base(message) { }
    }
}
