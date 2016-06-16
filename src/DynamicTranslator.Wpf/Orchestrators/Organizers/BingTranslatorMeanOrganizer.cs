﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DynamicTranslator.Constants;
using DynamicTranslator.Orchestrators.Model;
using DynamicTranslator.Orchestrators.Model.Bing;

using Newtonsoft.Json;

namespace DynamicTranslator.Wpf.Orchestrators.Organizers
{
    public class BingTranslatorMeanOrganizer : AbstractMeanOrganizer
    {
        public override TranslatorType TranslatorType => TranslatorType.Bing;

        public override Task<Maybe<string>> OrganizeMean(string text, string fromLanguageExtension)
        {
            var means = new StringBuilder();

            var response = JsonConvert.DeserializeObject<BingTranslatorResponse>(text);
            if (response.Translations.Any())
            {
                if (response.Translations.ContainsKey("Bing"))
                    means.AppendLine(response.Translations["Bing"]);
            }

            return Task.FromResult(new Maybe<string>(means.ToString()));
        }
    }
}