using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using StudyInfo.Logic.Infrastructure;

namespace StudyInfo.Logic.CognitiveServices
{
    public class SpellingChecker
    {
        private static readonly SpellCheckConfiguration Config = SpellCheckConfiguration.Resolve();

        static string host = "https://api.cognitive.microsoft.com";
        static string path = "/bing/v7.0/spellcheck?";

        public async Task<string> CheckSpellingAsync(string sentence)
        {
            string text = "text=" + sentence;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Config.ApiKey);

            string uri = host + path + text;


            response = await client.GetAsync(uri);


            var res = await response.Content.ReadAsStringAsync();
            return "";
        }
    }
}
