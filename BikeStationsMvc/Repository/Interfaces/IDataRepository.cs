using BikeStationsMvc.Data;


namespace BikeStationsMvc.Repository.Interfaces
{
    public interface IDataRepository
    {
        public List<Bike> GetAllBikes();
        public List<Station> GetAllStations();
        public bool Create(Bike bike);
        
        
    }
}
