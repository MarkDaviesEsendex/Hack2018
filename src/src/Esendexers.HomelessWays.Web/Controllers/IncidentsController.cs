using System.Threading.Tasks;
using Abp.ObjectMapping;
using Esendexers.HomelessWays.Services;
using Esendexers.HomelessWays.Web.Models.Incidents;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class IncidentsController : HomelessWaysControllerBase
    {
        private readonly IIncidentAppService _incidentAppService;

        public IncidentsController(IIncidentAppService incidentAppService)
        {
            _incidentAppService = incidentAppService;
        }

        [HttpGet]
        public async Task<IActionResult> NearbyIncidents(double latitude, double longitude, uint radius)
        {
            var incidents = await _incidentAppService.GetIncidentsAroundLocation(latitude, longitude, radius);

            return Ok(incidents);
        }
    }
}