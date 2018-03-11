using System.Collections.Generic;
using System.Threading.Tasks;
using Esendexers.HomelessWays.DTOs;
using Esendexers.HomelessWays.Services;
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
        [ProducesResponseType(typeof(IEnumerable<IncidentDto>), 200)]
        public async Task<IActionResult> NearbyIncidents(double latitude, double longitude, uint radius)
        {
            var incidents = await _incidentAppService.GetIncidentsAroundLocation(latitude, longitude, radius);
            return Ok(incidents);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IncidentDto>), 200)]
        public async Task<IActionResult> NearbyIncidentsWithTag(double latitude, double longitude, uint radius, string tag)
        {
            var incidents = await _incidentAppService.GetIncidentsAroundLocationWithTag(latitude, longitude, radius, tag);

            return Ok(incidents);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IncidentDto>), 200)]
        public async Task<IActionResult> IncidentsWithTag(string tag)
        {
            var incidents = await _incidentAppService.GetIncidentsWithTag(tag);

            return Ok(incidents);
        }
    }
}