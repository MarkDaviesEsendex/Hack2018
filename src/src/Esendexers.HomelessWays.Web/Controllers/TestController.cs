using System;
using Esendexers.HomelessWays.Inputs;
using Esendexers.HomelessWays.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class TestController : HomelessWaysControllerBase
    {
        private readonly ILanguageAnalysysService _languageAnalysys;
        private readonly IImageStorageService _imageStorageService;
        private readonly IIncidentAppService _incidentAppService;

        public TestController(ILanguageAnalysysService languageAnalysys, IIncidentAppService incidentAppService, IImageStorageService imageStorageService)
        {
            _languageAnalysys = languageAnalysys;
            _incidentAppService = incidentAppService;
            _imageStorageService = imageStorageService;
        }

        public IActionResult Test(string description) 
            => Ok(_languageAnalysys.GetSentimentScore(description));

        public IActionResult Image(string imageLocation) 
            => Ok(_imageStorageService.GetImageLink(imageLocation));

        public IActionResult Incident()
        {
            _incidentAppService.RecordNewIncident(new CreateIncidentInput
            {
                Description = "Really bad stuff is going down",
                Latitude = 1.0,
                Longitude = 1.0,
                Time = DateTime.Now
            });
            return Ok();
        }
    }
}