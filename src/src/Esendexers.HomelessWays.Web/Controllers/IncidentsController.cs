using Esendexers.HomelessWays.Web.Models.Incidents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class IncidentsController : HomelessWaysControllerBase
    {
        [HttpGet]
        public IActionResult IncidentsNearby(Coordinates currentLocation, uint radius)
        {
            return Ok(true);
        }
    }
}