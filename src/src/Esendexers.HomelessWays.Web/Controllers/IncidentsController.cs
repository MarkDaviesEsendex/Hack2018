using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Abp.IO.Extensions;
using Esendexers.HomelessWays.DTOs;
using Esendexers.HomelessWays.Inputs;
using Esendexers.HomelessWays.Services;
using Esendexers.HomelessWays.Web.Models.Incidents;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class IncidentsController : HomelessWaysControllerBase
    {
        private readonly IIncidentAppService _incidentAppService;
        private readonly IImageStorageService _imageStorageService;

        public IncidentsController(IIncidentAppService incidentAppService, IImageStorageService imageStorageService)
        {
            _incidentAppService = incidentAppService;
            _imageStorageService = imageStorageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IncidentDto>), 200)]
        public async Task<IActionResult> NearbyIncidents(double latitude, double longitude, uint radius) 
            => Ok(await _incidentAppService.GetIncidentsAroundLocation(latitude, longitude, radius));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IncidentDto>), 200)]
        public async Task<IActionResult> NearbyIncidentsWithTag(double latitude, double longitude, uint radius, string tag) 
            => Ok(await _incidentAppService.GetIncidentsAroundLocationWithTag(latitude, longitude, radius, tag));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<IncidentDto>), 200)]
        public async Task<IActionResult> IncidentsWithTag(string tag) 
            => Ok(await _incidentAppService.GetIncidentsWithTag(tag));

        [HttpGet]
        public async Task<IActionResult> GetBySentiment(double latitude, double longitude, uint radius) 
            => Ok(await _incidentAppService.GetIncidentsAroundLocationOrderBySentiment(latitude, longitude,
            radius));

        public IActionResult Index() 
            => View();

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]IncidentViewModel incidentViewModel)
        {
            if (incidentViewModel.Description.ToLower().Contains("space") &&
                incidentViewModel.Description.ToLower().Contains("invader"))
            {
                return RedirectToAction("Index", "Invaders");
            }

            var imageName = $"{Guid.NewGuid().ToString()}.jpg";
            var imageStream = new MemoryStream();
            incidentViewModel.File.CopyTo(imageStream);
            imageStream.Position = 0;

            var newIncidentInput = new CreateIncidentInput
            {
                Description = incidentViewModel.Description,
                Longitude = incidentViewModel.Longitude,
                Latitude = incidentViewModel.Latitude,
                Time = DateTime.Now,
                ImageName = imageName,
                ImageBytes = ReadFully(imageStream)
            };
            _incidentAppService.RecordNewIncident(newIncidentInput);
            await _imageStorageService.UploadImageBytes(imageName, imageStream.GetAllBytes());
            return View("Index");
        }

        public static byte[] ReadFully(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}