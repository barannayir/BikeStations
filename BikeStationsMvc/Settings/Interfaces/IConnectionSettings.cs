namespace BikeStationsMvc.Settings.Interfaces
{
    public interface IConnectionSettings
    {
        public string baseAdress { get; set; }
        public string getBikes { get; set; }
        public string createBike { get; set; }
        public string getStations { get; set; }
    }
}
