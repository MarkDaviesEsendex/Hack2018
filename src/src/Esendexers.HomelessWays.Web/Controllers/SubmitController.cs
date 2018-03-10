using Esendexers.HomelessWays.Web.Models.Submit;
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
}