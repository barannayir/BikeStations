using Newtonsoft.Json;
using BikeStationsApi.Data;
using BikeStationsApi.Repository.Interfaces;
using BikeStationsApi.Settings.Interfaces;

namespace BikeStationsApi.Repository
{
    public class BikeRepository : IBikeRepository
    {
        private List<Bike> _bikes;
        string _filePath;
        public BikeRepository(IDatabaseSettings databaseSettings)
        {
            _filePath = databaseSettings.BikesJson;
            _bikes = GetAll();
        }
    

        public void Create(Bike bike)
        {
            var jsonText = File.ReadAllText(_filePath);
            var data = JsonConvert.DeserializeObject<BikeData>(jsonText);
            data.Data.Bikes.Add(bike);
            var updatedJson = JsonConvert.SerializeObject(data);
            File.WriteAllText(_filePath, updatedJson);
        }

        public void Delete(string id)
        {
            var jsonText = File.ReadAllText(_filePath);
            var data = JsonConvert.DeserializeObject<BikeData>(jsonText);

            var existingBike = data.Data.Bikes.FirstOrDefault(x => x.bike_id == id);
            if (existingBike != null)
            {
                data.Data.Bikes.Remove(existingBike);
            }
        }

        public List<Bike> GetAll()
        {
            var json = File.ReadAllText(_filePath);
            var data = JsonConvert.DeserializeObject<BikeData>(json);
            return data.Data.Bikes.ToList();
        }

        public Bike GetById(string id)
        {
            var json = File.ReadAllText(_filePath);
            var bikes = GetAll();

            return bikes.FirstOrDefault(x => x.bike_id == id);
        }

        public void Update(string bikeId, Bike bike)
        {
            var jsonText = File.ReadAllText(_filePath);
            var data = JsonConvert.DeserializeObject<BikeData>(jsonText);
            
            var existingBike = data.Data.Bikes.FirstOrDefault(x => x.bike_id == bikeId);
            if (existingBike != null)
            {
                existingBike.name = bike.name;
                existingBike.station_id = bike.station_id;
                existingBike.is_disabled = bike.is_disabled;
                existingBike.is_reserved = bike.is_reserved;
            }
            var updatedJson = JsonConvert.SerializeObject(data);
            File.WriteAllText(_filePath, updatedJson);
        }

        public List<Bike> GetByAvailability(int isReserved)
        {
            return _bikes.Where(x => x.is_disabled == isReserved).ToList();
        }

        public List<Bike> GetByStation(string stationId)
        {
            return _bikes.Where(x => x.station_id == stationId).ToList();
        }
    }
}
