using BikeStationsApi.Data;
using BikeStationsApi.Repository.Interfaces;
using BikeStationsApi.Settings.Interfaces;
using Newtonsoft.Json;

namespace BikeStationsApi.Repository
{
    public class StationRepository : IStationRepository
    {
        private List<Station> _stations;
        string _filePath;
        public StationRepository(IDatabaseSettings databaseSettings)
        {
            _filePath = databaseSettings.StationsJson;
            _stations = GetAll();
        }
        public List<Station> GetAll()
        {
            var json = File.ReadAllText(_filePath);
            var data = JsonConvert.DeserializeObject<StationData>(json);
            return data.Data.Stations.ToList();
        }

        public Station GetById(string id)
        {
            var json = File.ReadAllText(_filePath);

            return _stations.FirstOrDefault(x => x.station_id == id);
        }
    }
}
