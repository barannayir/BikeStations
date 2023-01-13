using BikeStationsMvc.Data;
using BikeStationsMvc.Models;

using BikeStationsMvc.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BikeStationsMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataRepository _datarepository;

        public HomeController(ILogger<HomeController> logger, IDataRepository datarepository)
        {
            _logger = logger;
            _datarepository = datarepository;
        }

        public async Task<IActionResult> Index()
        {
            var bikes = _datarepository.GetAllBikes();


            if (bikes != null)
            {
                return View(bikes);
            }
            else
            {
                return View("Error");
            }

        }

        public ActionResult SearchBikes(string searchString)
        {
            //var bikes = _datarepository.GetAll();
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    bikes = bikes.Where(b => b.Name.Contains(searchString) || b.StationId.Contains(searchString));
            //}
            return View("GetBikes");
        }

        [HttpPost]
        public IActionResult Create(Bike bike)
        {

            if (_datarepository.Create(bike))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}