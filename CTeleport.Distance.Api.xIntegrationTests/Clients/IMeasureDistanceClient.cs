using Refit;
using System.Threading.Tasks;

namespace CTeleport.Distance.Api.xIntegrationTests.Clients
{
    [Headers("Accept: application/json")]
    interface IMeasureDistanceClient
    {
        [Get("/airports/distance")]
        Task<Model.Distance> GetDistance([Query] string firstAirportIATA, [Query] string secondAirportIATA);
    }
}
