using System;
using Esendexers.HomelessWays.Inputs;
using Esendexers.HomelessWays.Services;
using Esendexers.HomelessWays.Web.Models.Submit;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;

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
            var imageName = Guid.NewGuid().ToString();
            var imageBytes = Convert.FromBase64String(incident.Image);

            var newIncidentInput = new CreateIncidentInput
            {
                Description = incident.Description,
                Longitude = incident.Position.Longitude,
                Latitude = incident.Position.Latitude,
                Time = DateTime.Now,
                ImageName = imageName
            };
            return Ok(_incidentAppService.RecordNewIncident(newIncidentInput));
        }
    }
}