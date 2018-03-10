using System;
using System.IO;
using System.Threading.Tasks;
using Castle.Core.Logging;
using Esendexers.HomelessWays.Inputs;
using Esendexers.HomelessWays.Services;
using Esendexers.HomelessWays.Web.Models.Submit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;
using Newtonsoft.Json;
using SixLabors.ImageSharp;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class SubmitController : HomelessWaysControllerBase
    {
        private readonly IImageStorageService _imageStorageService;
        private readonly IIncidentAppService _incidentAppService;
        private readonly ILogger _logger;

        public SubmitController(IIncidentAppService incidentAppService, ILogger logger, IImageStorageService imageStorageService)
        {
            _incidentAppService = incidentAppService;
            _logger = logger;
            _imageStorageService = imageStorageService;
        }

        [HttpPost]
        public async Task<IActionResult> RecordIncident([FromBody]IncidentModel incident)
        {
            var imageName = $"{Guid.NewGuid().ToString()}.jpg";
            var imageBytes = Convert.FromBase64String(incident.Image);

            await _imageStorageService.UploadImageBytes(imageName, imageBytes);

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