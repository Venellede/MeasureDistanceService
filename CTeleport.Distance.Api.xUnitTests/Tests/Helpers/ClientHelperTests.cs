using CTeleport.Distance.Api.Exceptions;
using CTeleport.Distance.Api.Helpers;
using CTeleport.Distance.Api.Model;
using CTeleport.Distance.Api.xUnitTests.Mock;
using System.Threading.Tasks;
using Xunit;

namespace CTeleport.Distance.Api.xUnitTests.Tests.Helpers
{
    public class ClientHelperTests
    {
        [Fact, Trait("Owner", "AndreyK")]
        public async Task GetAndCheckAirportMetadata_EmptyAirport_EmptyAirportMetadataException()
        {
            var client = new AirportMetadataClientMock(null);

            await Assert.ThrowsAsync<EmptyAirportMetadataException>(async () => await client.GetAndCheckAirportMetadata("iata"));
        }

        [Fact, Trait("Owner", "AndreyK")]
        public async Task GetAndCheckAirportMetadata_InvalidIata_InvalidAirportMetadataException()
        {
            var client = new AirportMetadataClientMock(new Airport { Iata = "notIata" });

            await Assert.ThrowsAsync<InvalidAirportMetadataException>(async () => await client.GetAndCheckAirportMetadata("iata"));
        }

        [Fact, Trait("Owner", "AndreyK")]
        public async Task GetAndCheckAirportMetadata_NullLocation_AirportLocationNullException()
        {
            var client = new AirportMetadataClientMock(new Airport { Iata = "iata" });

            await Assert.ThrowsAsync<AirportLocationNullException>(async () => await client.GetAndCheckAirportMetadata("iata"));
        }

        [Fact, Trait("Owner", "AndreyK")]
        public async Task GetAndCheckAirportMetadata_AirportWithLocation_Airport()
        {
            var airport = new Airport { Iata = "iata", Location = new Location() };
            var client = new AirportMetadataClientMock(airport);

            var result = await client.GetAndCheckAirportMetadata("iata");
            Assert.Equal(airport, result);
        }
    }
}
