using CTeleport.Distance.Api.Clients;
using CTeleport.Distance.Api.Model;
using System.Threading.Tasks;

namespace CTeleport.Distance.Api.xUnitTests.Mock
{
    class AirportMetadataClientMock : IAirportMetadataClient
    {
        private readonly Airport _response;
        public AirportMetadataClientMock(Airport response)
        {
            _response = response;
        }
        public Task<Airport> GetAirportMetadata(string iata)
        {
            return Task.FromResult(_response);
        }
    }
}
