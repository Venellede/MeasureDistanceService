using Newtonsoft.Json;

namespace CTeleport.Distance.Api.Model
{
    public class Airport
    {
		public string Name { get; set; }
		public string Type { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public string Iata { get; set; }
		[JsonProperty("city_iata")]
		public string CityIata { get; set; }
		[JsonProperty("country_iata")]
		public string CountryIata { get; set; }
		[JsonProperty("timezone_region_name")]
		public string TimezoneRegionName { get; set; }
		public int Rating { get; set; }
		public Location Location { get; set; }
		public int Hubs { get; set; }
    }
}
