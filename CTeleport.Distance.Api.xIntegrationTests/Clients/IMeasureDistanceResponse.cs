﻿using Refit;
using System.Net.Http;
using System.Threading.Tasks;

namespace CTeleport.Distance.Api.xIntegrationTests.Clients
{
    [Headers("Accept: application/json")]
    interface IMeasureDistanceResponse
    {
        [Get("/airports/distance")]
        Task<HttpResponseMessage> GetDistance([Query] string firstAirportIATA, [Query] string secondAirportIATA);
    }
}
