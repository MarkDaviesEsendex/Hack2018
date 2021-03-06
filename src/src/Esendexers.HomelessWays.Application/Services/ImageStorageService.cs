﻿using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace Esendexers.HomelessWays.Services
{
    public interface IImageStorageService
    {
        Task<bool> UploadImageBytes(string imageName, byte[] imageBytes);
        string GetImageLink(string imageName);
    }

    public class ImageStorageService : HomelessWaysAppServiceBase, IImageStorageService
    {
        public async Task<bool> UploadImageBytes(string imageName, byte[] imageBytes)
        {
            var imageDirectory = GetImageDirectory();
            var file = imageDirectory.GetFileReference(imageName);

            await file.UploadFromStreamAsync(new MemoryStream(imageBytes), AccessCondition.GenerateEmptyCondition(),
                new FileRequestOptions(), new OperationContext());
            return true;
        }

        public string GetImageLink(string imageName)
        {
            var imageDirectory = GetImageDirectory();
            var file = imageDirectory.GetFileReference(imageName);
            return file.Uri.ToString() +
                   "?sv=2017-07-29&ss=bfqt&srt=sco&sp=rwdlacup&se=2018-03-11T19:49:13Z&st=2018-03-11T11:49:13Z&spr=https&sig=snAM2gRbXtMO9L1ItjYIyXT0L1UQb7VYiQtBJQ1bpNM%3D";
        }

        private static CloudFileDirectory GetImageDirectory()
        {
            var storageAccount = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=citysaves;AccountKey=Uk3eaRSJ9LW7+YCJ9d2qWwKjePIPAQsmhLvIOkN0BqTTC4pHrU6tebPDBhFGb0KFnyIMS9pHm3z+IjRkk7RAkw==");

            var fileClient = storageAccount.CreateCloudFileClient();
            var share = fileClient.GetShareReference("citysaves");
            var rootDirectory = share.GetRootDirectoryReference();
            var imageDirectory = rootDirectory.GetDirectoryReference("Images");
            return imageDirectory;
        }
    }
}