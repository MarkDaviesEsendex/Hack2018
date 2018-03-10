using System;
using Castle.Core.Logging;
using Esendexers.HomelessWays.Inputs;
using Esendexers.HomelessWays.Services;
using Esendexers.HomelessWays.Web.Models.Submit;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SixLabors.ImageSharp;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class SubmitController : HomelessWaysControllerBase
    {
        private readonly IIncidentAppService _incidentAppService;
        private readonly ILogger _logger;

        public SubmitController(IIncidentAppService incidentAppService, ILogger logger)
        {
            _incidentAppService = incidentAppService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult RecordIncident([FromBody]IncidentModel incident)
        {
            var imageName = Guid.NewGuid().ToString();
//            var imageBytes = Convert.FromBase64String(incident.Image);

            _logger.Info(JsonConvert.SerializeObject(incident));

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