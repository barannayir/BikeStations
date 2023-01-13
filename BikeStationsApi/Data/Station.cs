namespace BikeStationsApi.Data
{
    public class Station
    {
        public string station_id { get; set; }
        public string name { get; set; }
        public string region_id { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
        public string address { get; set; }
        public List<string> rental_methods { get; set; }
    }

    public class StationData
    {
        public long LastUpdated { get; set; }
        public int Ttl { get; set; }
        public StationDataDetails Data { get; set; }
    }

    public class StationDataDetails
    {
        public List<Station> Stations { get; set; }
    }
}
