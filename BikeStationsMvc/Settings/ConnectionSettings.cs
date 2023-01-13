using BikeStationsMvc.Settings.Interfaces;

namespace BikeStationsMvc.Settings
{
    public class ConnectionSettings : IConnectionSettings
    {
        public string baseAdress { get; set; }
        public string getBikes { get; set; }
        public string createBike { get; set; }
        public string getStations { get; set; }
    }
}
