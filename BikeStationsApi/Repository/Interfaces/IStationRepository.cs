using BikeStationsApi.Data;

namespace BikeStationsApi.Repository.Interfaces
{
    public interface IStationRepository
    {
        public List<Station> GetAll();
        public Station GetById(string id);
    }
}
