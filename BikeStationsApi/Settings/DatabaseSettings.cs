using BikeStationsApi.Settings.Interfaces;

namespace BikeStationsApi.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string BikesJson { get; set; }
        public string StationsJson { get; set; }
    }
}
