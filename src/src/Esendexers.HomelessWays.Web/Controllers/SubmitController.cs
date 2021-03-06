﻿using System;
using System.Threading.Tasks;
using Esendexers.HomelessWays.Inputs;
using Esendexers.HomelessWays.Services;
using Esendexers.HomelessWays.Web.Models.Submit;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class SubmitController : HomelessWaysControllerBase
    {
        private readonly IImageStorageService _imageStorageService;
        private readonly IIncidentAppService _incidentAppService;

        public SubmitController(IIncidentAppService incidentAppService, IImageStorageService imageStorageService)
        {
            _incidentAppService = incidentAppService;
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
                ImageName = imageName,
                ImageBytes = imageBytes
            };
            _incidentAppService.RecordNewIncident(newIncidentInput);
            return Ok();
        }
    }
}