using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;

namespace Esendexers.HomelessWays.Services
{
    public interface ILanguageAnalysysService
    {
        double GetSentimentScore(string description);
        string[] GetKeyPrases(string description);
    }

    public class LanguageAnalysysService :  HomelessWaysAppServiceBase, ILanguageAnalysysService
    {
        public double GetSentimentScore(string description)
        {
            var client = TextAnalyticsApi();
            var language = GetFirstDetectedLanguage(description, client);

            var sentiment = client.Sentiment(new MultiLanguageBatchInput(
                new List<MultiLanguageInput> {new MultiLanguageInput(language.Iso6391Name, "0", description)}));
            return sentiment.Documents.First().Score ?? 0;
        }

        public string[] GetKeyPrases(string description)
        {
            var client = TextAnalyticsApi();
            var language = GetFirstDetectedLanguage(description, client);

            var keyPhrases = client.KeyPhrases(new MultiLanguageBatchInput(
                new List<MultiLanguageInput> { new MultiLanguageInput(language.Iso6391Name, "0", description) }));
            return keyPhrases.Documents.First().KeyPhrases.ToArray();
        }

        private static DetectedLanguage GetFirstDetectedLanguage(string description, ITextAnalyticsAPI client)
        {
            var result = client.DetectLanguage(new BatchInput(new List<Input> {new Input("1", description)}));
            return result.Documents.First().DetectedLanguages.First();
        }

        private static TextAnalyticsAPI TextAnalyticsApi() => new TextAnalyticsAPI
        {
            AzureRegion = AzureRegions.Westcentralus,
            SubscriptionKey = "48bb9c86473d4de58d5df8fe98c2b5f4"
        };
    }

}