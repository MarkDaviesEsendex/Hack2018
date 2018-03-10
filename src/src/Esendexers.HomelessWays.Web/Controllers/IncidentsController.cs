using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class IncidentsController : HomelessWaysControllerBase
    {
        [HttpGet]
        public IActionResult IncidentsNearby(Coordinates currentLocation, uint radius)
        {
//            currentLocation.
            return Json("hi");
        }
    }

    public class Coordinates
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}