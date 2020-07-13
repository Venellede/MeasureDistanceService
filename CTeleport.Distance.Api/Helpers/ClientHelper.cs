using CTeleport.Distance.Api.Clients;
using CTeleport.Distance.Api.Exceptions;
using CTeleport.Distance.Api.Model;
using System.Threading.Tasks;

namespace CTeleport.Distance.Api.Helpers
{
    public static class ClientHelper
    {
        public static async Task<Airport> GetAndCheckAirportMetadata(this IAirportMetadataClient client, string iata)
        {
            var airport = await client.GetAirportMetadata(iata);

            if (airport == null)
                throw new EmptyAirportMetadataException($"Metadata for airport iada {iata} is null");

            if (airport.Iata != iata)
                throw new InvalidAirportMetadataException($"Invalid recieved airport IATA code. Requested {iata}, recieved {airport.Iata}");

            if (airport.Location == null)
                throw new AirportLocationNullException($"Location for requested {iata} airport is null");

            return airport;
        }
    }
}
