using System.Collections.Generic;
using Microsoft.Bot.Builder;
using Newtonsoft.Json;

namespace StudyInfo.Bot.Models
{
    public class CourseRecognizerConvert : IRecognizerConvert
    {
        public string Text { get; set; }
        public string AlteredText { get; set; }

        public Dictionary<string, IntentScore> Intents { get; set; }

        public _Entities Entities { get; set; }

        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> Properties { get; set; }

        public void Convert(dynamic result)
        {
            var app = JsonConvert.DeserializeObject<CourseRecognizerConvert>(JsonConvert.SerializeObject(result));
            Text = app.Text;
            AlteredText = app.AlteredText;
            Intents = app.Intents;
            Entities = app.Entities;
            Properties = app.Properties;
        }

        public class _Entities
        {
            [JsonProperty("$instance")]
            public Instance Instance { get; set; }
            public string[][] Courses { get; set; }
        }

        public class Instance
        {
            public Course[] Courses { get; set; }
        }

        public class Course
        {
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
            public string Text { get; set; }
            public string Type { get; set; }
        }
    }
}
