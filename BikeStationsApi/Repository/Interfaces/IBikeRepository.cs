
using BikeStationsApi.Data;

namespace BikeStationsApi.Repository.Interfaces
{
    public interface IBikeRepository
    {
        public List<Bike> GetAll();
        public List<Bike> GetByAvailability(int isReserved);
        public List<Bike> GetByStation(string stationId);
        public Bike GetById(string id);
        public void Delete(string id);
        public void Create(Bike bike);
        public void Update(string bikeId, Bike bike);

    }
}
