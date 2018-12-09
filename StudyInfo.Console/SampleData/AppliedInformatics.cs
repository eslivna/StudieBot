using System.Collections.Generic;
using Newtonsoft.Json;
using StudyInfo.Logic.Data.Domain;

namespace StudyInfo.ConsoleApp.SampleData
{
    public static class AppliedInformatics
    {
        public static IList<CourseDataEntity> Data => new List<CourseDataEntity>
        {
            new CourseDataEntity(){RowKey="Computerarchitectuur", Course = "Computerarchitectuur", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,18,51))}
        };
    }
}
