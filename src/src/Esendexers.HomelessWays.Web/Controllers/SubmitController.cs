using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class SubmitController : HomelessWaysControllerBase
    {
        [HttpPost]
        public IActionResult RecordIncident(IncidentModel incident)
        {
            return Ok(true);
        }
    }

    public class IncidentModel
    {
        public IFormFile IncidentImage { get; set; }
        public string Latitude { get;set; }
        public string Longitude { get; set; }
        public string Description { get; set; }
    }
}