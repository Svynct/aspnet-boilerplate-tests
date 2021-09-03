using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Projeto.AspNet.Localization
{
    public static class AspNetLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AspNetConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AspNetLocalizationConfigurer).GetAssembly(),
                        "Projeto.AspNet.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
