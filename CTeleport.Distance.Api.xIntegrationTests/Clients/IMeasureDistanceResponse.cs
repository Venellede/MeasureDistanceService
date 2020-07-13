using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace CTeleport.Distance.Api.xIntegrationTests.Clients
{
    [Headers("Accept: application/json")]
    interface IMeasureDistanceResponse
    {
        [Get("/airports/{firstAirportIata}/distance/{secondAirportIata}")]
        Task<HttpResponseMessage> GetDistance(string firstAirportIata, string secondAirportIata);
    }
}
