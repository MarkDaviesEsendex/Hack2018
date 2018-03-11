using Esendexers.HomelessWays.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class ImageController : HomelessWaysControllerBase
    {
        private readonly IImageStorageService _imageStorageService;

        public ImageController(IImageStorageService imageStorageService) 
            => _imageStorageService = imageStorageService;

        public IActionResult GetUrl(string imageName) 
            => Ok(_imageStorageService.GetImageLink(imageName));
    }
}