using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyInfo.Logic.Data;
using StudyInfo.Logic.Data.Domain.Course;
using StudyInfo.Logic.Data.Domain.Luis;

namespace StudyInfo.Bot.Helper
{
    public static class CourseIntentionHandler
    {
        public static async Task<string> GetResponseTextAsync(IDatabaseService dbService, LuisResult result)
        {
            var course = await dbService.Get<CourseDataEntity>(result.Entity.Value);

            switch (result.Intent)
            {
                case IntentType.Get_Name_Teacher:
                    return $"{course.Course} wordt gegeven door {course.Teacher}";
                case IntentType.Get_Study_Time:
                    var studyTime = JsonConvert.DeserializeObject<StudyTime>(course.StudyTime);
                    return $"Voor het vak {course.Course} kan je best {studyTime.TotalStudyTime} uur uitrekenen.";
                case IntentType.Get_Number_Of_Credits:
                    return $"Het vak {course.Course} bevat {course.StudyLoad} studiepunten";
                case IntentType.None:
                    return string.Empty;
            }
            return string.Empty;
        }
    }
}
