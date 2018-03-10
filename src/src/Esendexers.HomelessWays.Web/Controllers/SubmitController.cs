using System;
using Esendexers.HomelessWays.Inputs;
using Esendexers.HomelessWays.Services;
using Esendexers.HomelessWays.Web.Models.Submit;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class SubmitController : HomelessWaysControllerBase
    {
        private readonly IIncidentAppService _incidentAppService;

        public SubmitController(IIncidentAppService incidentAppService)
        {
            _incidentAppService = incidentAppService;
        }

        [HttpPost]
        public IActionResult RecordIncident(IncidentModel incident)
        {
            var newIncidentInput = new CreateIncidentInput
            {
                Description = incident.Description,
                Longitude = incident.Longitude,
                Latitude = incident.Latitude,
                Time = DateTime.Now,
            };
            incident.IncidentImage.CopyTo(newIncidentInput.ImageStream);
            return Ok(_incidentAppService.RecordNewIncident(newIncidentInput));
        }
    }
}