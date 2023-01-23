using BikeStationsApi.Data;
using BikeStationsApi.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BikeStationsApi.Controllers
{
    [Route("api/[controller]")]
    [Consumes("application/json")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBikeRepository _bikeRepository;
        private readonly IStationRepository _stationRepository;

        public HomeController(IBikeRepository bikeRepository, IStationRepository stationRepository)
        {
            _bikeRepository = bikeRepository;
            _stationRepository = stationRepository;
        }
        [HttpGet("GetBikes")]
        public IActionResult GetBikes()
        {
            return Ok(_bikeRepository.GetAll());
        }
        [HttpGet("GetStations")]
        public IActionResult GetStations()
        {
            return Ok(_stationRepository.GetAll());
        }

        [HttpGet("GetByStation/{stationId}")]
        public IActionResult GetByStation(string stationId)
        {
            return Ok(_bikeRepository.GetByStation(stationId));
        }

        [HttpGet("stations/statistics")]
        public IActionResult GetStationStatistics()
        {
            var bikes = _bikeRepository.GetAll();
            var stationStatistics = bikes
                .GroupBy(b => b.station_id)
                .Select(g => new { StationId = g.Key, BikeCount = g.Count() })
                .ToList();

            return Ok(stationStatistics);
        }

        [HttpPost("CreateBike")]
        [Consumes("application/json")]
        public IActionResult CreateBike([FromBody] Bike bike)
        {
            _bikeRepository.Create(bike);
            return Ok();
        }



    }
}
