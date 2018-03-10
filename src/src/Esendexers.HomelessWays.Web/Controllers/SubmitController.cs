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
        private readonly IIncidentAppService _incidentAppService;
        private readonly ILogger _logger;

        public SubmitController(IIncidentAppService incidentAppService, ILogger logger)
        {
            _incidentAppService = incidentAppService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> RecordIncident([FromBody]IncidentModel incident)
        {
            var imageName = $"{Guid.NewGuid().ToString()}.jpg";
            var imageBytes = Convert.FromBase64String(incident.Image);

            var storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=citysaves;AccountKey=Uk3eaRSJ9LW7+YCJ9d2qWwKjePIPAQsmhLvIOkN0BqTTC4pHrU6tebPDBhFGb0KFnyIMS9pHm3z+IjRkk7RAkw==");

            var fileClient = storageAccount.CreateCloudFileClient();
            var share = fileClient.GetShareReference("citysaves");
            var rootDirectory = share.GetRootDirectoryReference();
            var imageDirectory = rootDirectory.GetDirectoryReference("Images");
            var file = imageDirectory.GetFileReference(imageName);

            await file.UploadFromStreamAsync(new MemoryStream(imageBytes), AccessCondition.GenerateEmptyCondition(),
                new FileRequestOptions(), new OperationContext());

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