using System.Collections.Generic;
using Newtonsoft.Json;
using StudyInfo.Logic.Data.Domain.Course;

namespace StudyInfo.ConsoleApp.SampleData
{
    public static class AppliedInformatics
    {
        public static IList<CourseDataEntity> Data => new List<CourseDataEntity>
        {
            //Courses first year
            new CourseDataEntity(){RowKey="Computerarchitectuur", Course = "Computerarchitectuur", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,18,51))},
            new CourseDataEntity(){RowKey="Computernetwerken1", Course = "Computernetwerken I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,30,64))},
            new CourseDataEntity(){RowKey="OOProgrammeren1", Course = "OO Programmeren I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Analyse1", Course = "Analyse I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,8,16,51))},
            new CourseDataEntity(){RowKey="OOOntwerpen1", Course = "OO Ontwerpen I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,18,18,64))},
            new CourseDataEntity(){RowKey="Databanken1", Course = "Databanken I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,24,64))},
            new CourseDataEntity(){RowKey="Webapplicaties1", Course = "Webapplicaties I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,24,51))},
            new CourseDataEntity(){RowKey="PartimFinancieelManagement", Course = "Partim Financieel Management", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,64))},
            new CourseDataEntity(){RowKey="PartimStrategischManagement", Course = "Partim Strategisch Management", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,26))},
            new CourseDataEntity(){RowKey="Math4IT", Course = "Math4IT", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,52))},
            new CourseDataEntity(){RowKey="Probleemoplossenddenken1", Course = "Probleemoplossend denken I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,77))},
            new CourseDataEntity(){RowKey="InternationaleCommunicatie1", Course = "Internationale Communicatie I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="i2Talent", Course = "i¹Talent", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="Projecten-workshops1", Course = "Projecten-workshops I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(36,12,0,102))},
            new CourseDataEntity(){RowKey="OOProgrammeren2", Course = "OO Programmeren II", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Webapplicaties2", Course = "Webapplicaties II", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))}

            //Courses second year


            //Courses third year
        };
    }
}
