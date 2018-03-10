using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Esendexers.HomelessWays.Localization
{
    public static class HomelessWaysLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(HomelessWaysConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HomelessWaysLocalizationConfigurer).GetAssembly(),
                        "Esendexers.HomelessWays.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
