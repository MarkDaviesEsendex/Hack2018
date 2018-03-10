using System;
using System.IO;
using System.Threading.Tasks;
using Esendexers.HomelessWays.Inputs;
using Esendexers.HomelessWays.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class TestController : HomelessWaysControllerBase
    {
        private readonly ILanguageAnalysysService _languageAnalysys;
        private IImageAnalysisService _imageAnalysis;
        private readonly IIncidentAppService _incidentAppService;

        public TestController(ILanguageAnalysysService languageAnalysys, IIncidentAppService incidentAppService, IImageAnalysisService imageAnalysis)
        {
            _languageAnalysys = languageAnalysys;
            _incidentAppService = incidentAppService;
            _imageAnalysis = imageAnalysis;
        }

        public IActionResult Test(string description) 
            => Ok(_languageAnalysys.GetSentimentScore(description));

        public async Task<IActionResult> Image(string imageLocation)
        {
            var imageName = Guid.NewGuid().ToString();
            var filStream = System.IO.File.Open(imageLocation, FileMode.Open);

            var storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=citysaves;AccountKey=Uk3eaRSJ9LW7+YCJ9d2qWwKjePIPAQsmhLvIOkN0BqTTC4pHrU6tebPDBhFGb0KFnyIMS9pHm3z+IjRkk7RAkw==");

            var fileClient = storageAccount.CreateCloudFileClient();
            var share = fileClient.GetShareReference("citysaves");
            var rootDirectory = share.GetRootDirectoryReference();
            var imageDirectory = rootDirectory.GetDirectoryReference("Images");
            var file = imageDirectory.GetFileReference(imageName);

            await file.UploadFromStreamAsync(filStream, AccessCondition.GenerateEmptyCondition(),
                new FileRequestOptions(), new OperationContext());
            return Ok(true);
        }

        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

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