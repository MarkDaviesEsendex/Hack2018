using Esendexers.HomelessWays.Services;
using Microsoft.AspNetCore.Mvc;

namespace Esendexers.HomelessWays.Web.Controllers
{
    public class LanguageTestController : HomelessWaysControllerBase
    {
        private readonly ILanguageAnalysysService _languageAnalysys;

        public LanguageTestController(ILanguageAnalysysService languageAnalysys)
        {
            _languageAnalysys = languageAnalysys;
        }

        public IActionResult Test(string description) 
            => Ok(_languageAnalysys.GetSentimentScore(description));
    }
}