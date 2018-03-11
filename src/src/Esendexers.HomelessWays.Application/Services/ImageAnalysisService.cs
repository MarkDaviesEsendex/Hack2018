using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Esendexers.HomelessWays.Services
{
    public interface IImageAnalysisService
    {
        Task<ImageAnalysisResult> AnalyzeImage(byte[] imageBytes);
    }

    public class ImageAnalysisService : HomelessWaysAppServiceBase, IImageAnalysisService
    {
        private const string SubscriptionKey = "63cde587f23a4085bb077d4627384733";
        private const string UriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/analyze";

        public async Task<ImageAnalysisResult> AnalyzeImage(byte[] imageBytes)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);

            const string uri = UriBase + "?visualFeatures=Categories,Description,Color&language=en";

            using (var content = new ByteArrayContent(imageBytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                var response = await client.PostAsync(uri, content);

                return JsonConvert.DeserializeObject<ImageAnalysisResult>(await response.Content.ReadAsStringAsync());
            }
        }
    }

    public class ImageAnalysisResult
    {
        public ImageCategory[] Categories { get; set; }
        public ImageDescription Description { get; set; }
    }

    public class ImageCategory
    {
        public string Name { get; set; }
        public double? Score { get; set; }
        public ImageDescription Description { get; set; }
    }

    public class ImageDescription
    {
        public string[] Tags { get; set; }
        public ImageCaptions[] Captions { get; set; }
    }

    public class ImageCaptions
    {
        public string Text { get; set; }
        public double? Confidence { get; set; }
    }
}