﻿// <auto-generated>
// Code generated by LUISGen C:\Users\vanacoleyene\Downloads\7e9e1e64-fb89-4fda-be38-867b7bc25698_v0.1.json -cs StudyInfo.CourseModel -o C:\Users\vanacoleyene\Downloads
// Tool github: https://github.com/microsoft/botbuilder-tools
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
namespace StudyInfo.Bot.Models
{
    public class DispatchModel : IRecognizerConvert
    {
        public string Text;
        public string AlteredText;
        public enum Intent
        {
            l_HoGentGeneral,
            l_Training_Courses,
            q_General,
            None,
        };
        public Dictionary<Intent, IntentScore> Intents;

        public class _Entities
        {

            // Lists
            public string[][] Courses;

            // Instance
            public class _Instance
            {
                public InstanceData[] Courses;
            }
            [JsonProperty("$instance")]
            public _Instance _instance;
        }
        public _Entities Entities;

        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> Properties { get; set; }

        public void Convert(dynamic result)
        {
            var app = JsonConvert.DeserializeObject<DispatchModel>(JsonConvert.SerializeObject(result));
            Text = app.Text;
            AlteredText = app.AlteredText;
            Intents = app.Intents;
            Entities = app.Entities;
            Properties = app.Properties;
        }

        public (Intent intent, double score) TopIntent()
        {
            Intent maxIntent = Intent.None;
            var max = 0.0;
            foreach (var entry in Intents)
            {
                if (entry.Value.Score > max)
                {
                    maxIntent = entry.Key;
                    max = entry.Value.Score.Value;
                }
            }
            return (maxIntent, max);
        }
    }
}
