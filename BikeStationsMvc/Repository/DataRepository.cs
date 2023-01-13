using BikeStationsMvc.Data;
using BikeStationsMvc.Repository.Interfaces;
using BikeStationsMvc.Settings.Interfaces;

namespace BikeStationsMvc.Repository
{
    public class DataRepository : IDataRepository
    {

        public readonly IConnectionSettings _connectionSettings;
        public string baseAdress;
        public string getBikes;
        public string createBike;
        public string getStations;

        public DataRepository(IConnectionSettings connectionSettings)
        {
            _connectionSettings = connectionSettings;
            this.baseAdress = connectionSettings.baseAdress;
            this.getBikes = connectionSettings.getBikes;
            this.createBike = connectionSettings.createBike;
            this.getStations = connectionSettings.getStations;
        }



        
        
        public bool Create(Bike bike)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAdress);
                var responseTask = client.PostAsJsonAsync(createBike, bike);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public List<Bike> GetAllBikes()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAdress);
                //HTTP GET
                var responseTask = client.GetAsync(getBikes);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<List<Bike>>();
                    readTask.Wait();

                    var bikes = readTask.Result;
                    return bikes;
                }
                else 
                {
                    
                    return null;
                }
            }
        }
        public List<Station> GetAllStations()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAdress);
                //HTTP GET
                var responseTask = client.GetAsync(getStations);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<List<Station>>();
                    readTask.Wait();

                    var stations = readTask.Result;
                    return stations;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
