using Newtonsoft.Json;

namespace BikeStationsMvc.Data
{
    public class Bike
    {
        [JsonProperty(PropertyName = "bike_id")]
        public string bike_id { get; set; }
        [JsonProperty(PropertyName = "station_id")]
        public string station_id { get; set; }
        [JsonProperty(PropertyName = "name")]

        public string? name { get; set; } = null;
        [JsonProperty(PropertyName = "lon")]

        public double? lon { get; set; } = null;
        [JsonProperty(PropertyName = "lat")]

        public double? lat { get; set; } = null;
        [JsonProperty(PropertyName = "is_reserved")]

        public int? is_reserved { get; set; } = null;
        [JsonProperty(PropertyName = "is_disabled")]
        public int? is_disabled { get; set; } = null;
    }

  
}
