using CTeleport.Distance.Api.Model;
using Refit;
using System.Threading.Tasks;

namespace CTeleport.Distance.Api.Clients
{
    [Headers("Accept: application/json")]
    public interface IAirportMetadataClient
    {
        [Get("/airports/{iata}")]
        Task<Airport> GetAirportMetadata(string iata);
    }
}
