using Newtonsoft.Json;

namespace CTeleport.Distance.Api.Model
{
    public class Location
    {
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
    }
}
