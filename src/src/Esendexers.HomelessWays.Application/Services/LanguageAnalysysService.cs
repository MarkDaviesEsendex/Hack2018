using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace Esendexers.HomelessWays.Services
{
    public class LanguageAnalysysService :  HomelessWaysAppServiceBase, ILanguageAnalysysService
    {
        public double GetSentimentScore(string description)
        {
            var client = new TextAnalyticsAPI
            {
                AzureRegion = AzureRegions.Westcentralus,
                SubscriptionKey = "48bb9c86473d4de58d5df8fe98c2b5f4"
            };

            var result = client.DetectLanguage(new BatchInput(new List<Input> {new Input("1", description)}));
            var language = result.Documents.First().DetectedLanguages.First();

            var sentiment = client.Sentiment(new MultiLanguageBatchInput(
                new List<MultiLanguageInput> {new MultiLanguageInput(language.Iso6391Name, "0", description)}));
            return sentiment.Documents.First().Score ?? 0;
        }
    }

    public interface ILanguageAnalysysService
    {
        double GetSentimentScore(string description);
    }
}