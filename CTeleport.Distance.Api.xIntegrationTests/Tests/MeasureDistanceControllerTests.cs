using CTeleport.Distance.Api.xIntegrationTests.Clients;
using CTeleport.Distance.Api.xIntegrationTests.Fixtures;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CTeleport.Distance.Api.xIntegrationTests.Tests
{
    [Collection("Measure Distance Fixture")]
    public class MeasureDistanceControllerTests 
    {
        private MeasureDistanceFixture<Startup> Fixture { get; }
        public MeasureDistanceControllerTests(MeasureDistanceFixture<Startup> fixture)
        {
            Fixture = fixture;
        }

        [Fact, Trait("Owner", "AndreyK")]
        public async Task GetDistanceBetweenAirports_SVOandDME_OkWithData()
        {
            var client = (IMeasureDistanceClient) Fixture.ServiceProvider.GetService(typeof(IMeasureDistanceClient));

            var result = await client.GetDistance("SVO", "DME");

            Assert.Equal(42.5569296364556, result);
        }


        [Fact, Trait("Owner", "AndreyK")]
        public async Task GetDistanceBetweenAirports_LowercaseIata_NotFound()
        {
            var client = (IMeasureDistanceResponse)Fixture.ServiceProvider.GetService(typeof(IMeasureDistanceResponse));

            var result = await client.GetDistance("svo", "DME");

            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }


        [Fact, Trait("Owner", "AndreyK")]
        public async Task GetDistanceBetweenAirports_InvalidIata_OkWithData()
        {
            var client = (IMeasureDistanceResponse)Fixture.ServiceProvider.GetService(typeof(IMeasureDistanceResponse));

            var result = await client.GetDistance("SVO1", "DME");

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Fact, Trait("Owner", "AndreyK")]
        public async Task GetDistanceBetweenAirports_EmptyIata_OkWithData()
        {
            var client = (IMeasureDistanceResponse)Fixture.ServiceProvider.GetService(typeof(IMeasureDistanceResponse));

            var result = await client.GetDistance("", "");

            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }
    }
}
