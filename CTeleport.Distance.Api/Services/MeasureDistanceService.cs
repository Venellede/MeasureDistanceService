using CTeleport.Distance.Api.Clients;
using CTeleport.Distance.Api.Helpers;
using CTeleport.Distance.Api.Model;
using CTeleport.Distance.Api.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CTeleport.Distance.Api.Services
{
    public class MeasureDistanceService : IMeasureDistanceService
    {
        private readonly IServiceProvider _serviceProvider;
        public MeasureDistanceService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<double> GetDistance(string fromIATACode, string toIATACode)
        {
            var client = _serviceProvider.GetRequiredService<IAirportMetadataClient>();
            var fromAirport = await client.GetAndCheckAirportMetadata(fromIATACode);
            var toAirport = await client.GetAndCheckAirportMetadata(toIATACode);
            return Calculator.MeasureDistance(fromAirport.Location.Latitude, fromAirport.Location.Longitude, toAirport.Location.Latitude, toAirport.Location.Longitude);
        }
    }
}
