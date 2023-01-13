namespace BikeStationsApi.Data
{
    public class Bike
    {
        public string bike_id { get; set; }
        public string station_id { get; set; }
        public string? name { get; set; }
        public double? lon { get; set; }
        public double? lat { get; set; }
        public int? is_reserved { get; set; }
        public int? is_disabled { get; set; }
    }

    public class BikeData
    {
        public long LastUpdated { get; set; }
        public int Ttl { get; set; }
        public BikeDataDetails Data { get; set; }
    }

    public class BikeDataDetails
    {
        public List<Bike> Bikes { get; set; }
    }
}
