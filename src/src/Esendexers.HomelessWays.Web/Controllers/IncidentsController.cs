using Abp.ObjectMapping;
using Esendexers.HomelessWays.Services;
using Esendexers.HomelessWays.Web.Models.Incidents;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class IncidentsController : HomelessWaysControllerBase
    {
        private readonly IIncidentService _incidentService;

        private readonly IObjectMapper _objectMapper;

        public IncidentsController(IIncidentService incidentService, IObjectMapper objectMapper)
        {
            _incidentService = incidentService;
            _objectMapper = objectMapper;
        }

        [HttpGet]
        public IActionResult IncidentsNearby(Coordinates currentLocation, uint radius)
        {
            _incidentService.GetIncidentsAroundLocation(_objectMapper.Map<HomelessWays.Models.Coordinates>(currentLocation), radius);

            return Ok(true);
        }
    }
}