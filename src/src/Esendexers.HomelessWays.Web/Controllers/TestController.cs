using System;
using Esendexers.HomelessWays.Inputs;
using Esendexers.HomelessWays.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class TestController : HomelessWaysControllerBase
    {
        private readonly ILanguageAnalysysService _languageAnalysys;
        private readonly IIncidentAppService _incidentAppService;

        public TestController(ILanguageAnalysysService languageAnalysys, IIncidentAppService incidentAppService)
        {
            _languageAnalysys = languageAnalysys;
            _incidentAppService = incidentAppService;
        }

        public IActionResult Test(string description) 
            => Ok(_languageAnalysys.GetSentimentScore(description));

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