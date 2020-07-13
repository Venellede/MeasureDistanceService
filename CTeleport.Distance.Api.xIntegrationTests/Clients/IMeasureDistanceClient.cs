using Refit;
using System.Threading.Tasks;

namespace CTeleport.Distance.Api.xIntegrationTests.Clients
{
    [Headers("Accept: application/json")]
    interface IMeasureDistanceClient
    {
        [Get("/airports/{firstAirportIata}/distance/{secondAirportIata}")]
        Task<double> GetDistance(string firstAirportIata, string secondAirportIata);
    }
}
