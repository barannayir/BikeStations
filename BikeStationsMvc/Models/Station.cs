namespace BikeStationsMvc.Data
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
    
}
