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
            new CourseDataEntity(){RowKey="Bedrijfsmanagement", Course = "Bedrijfsmanagement", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,18,51))},
            new CourseDataEntity(){RowKey="IT2Business", Course = "IT2Business", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,30,64))},
            new CourseDataEntity(){RowKey="Analyse II", Course = "Analyse II", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Onderzoekstechnieken", Course = "Onderzoekstechnieken", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,8,16,51))},
            new CourseDataEntity(){RowKey="Probleemoplossend denken II", Course = "Probleemoplossend denken II", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,18,18,64))},
            new CourseDataEntity(){RowKey="Databanken II", Course = "Databanken II", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,24,64))},
            new CourseDataEntity(){RowKey="Besturingssystemen", Course = "Besturingssystemen", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,24,51))},
            new CourseDataEntity(){RowKey="Internationale Communicatie II", Course = "Internationale Communicatie II", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,64))},
            new CourseDataEntity(){RowKey="i²Talent", Course = "i²Talent", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,26))},
            new CourseDataEntity(){RowKey="OO Programmeren III", Course = "OO Programmeren III", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,52))},
            new CourseDataEntity(){RowKey="Webapplicaties III", Course = "Webapplicaties III", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,77))},
            new CourseDataEntity(){RowKey="OO Ontwerpen II", Course = "OO Ontwerpen II", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="OO Ontwerpen III", Course = "OO Ontwerpen III", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="Webapplicaties IV", Course = "Webapplicaties IV", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(36,12,0,102))},
            new CourseDataEntity(){RowKey="Projecten-workshops II: Programmeren", Course = "Projecten-workshops II: Programmeren", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Computernetwerken II", Course = "Computernetwerken II", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Computernetwerken III", Course = "Computernetwerken III", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Projecten-workshops II: Systeembeheer", Course = "Projecten-workshops II: Systeembeheer", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},

            //Courses third year
            new CourseDataEntity(){RowKey="Analyse III", Course = "Analyse III", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,18,51))},
            new CourseDataEntity(){RowKey="Databanken III", Course = "Databanken III", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,30,64))},
            new CourseDataEntity(){RowKey="Internationale Communicatie III", Course = "Internationale Communicatie III", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Artificiële Intelligentie", Course = "Artificiële Intelligentie (TI)", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,8,16,51))},
            new CourseDataEntity(){RowKey="Native apps I", Course = "Native apps I", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,18,18,64))},
            new CourseDataEntity(){RowKey="Native apps II: mobile apps voor Windows", Course = "Native apps II: mobile apps voor Windows", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,24,64))},
            new CourseDataEntity(){RowKey="Native apps II: mobile apps voor iOS", Course = "Native apps II: mobile apps voor iOS", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,24,51))},
            new CourseDataEntity(){RowKey="Web apps", Course = "Web apps", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,64))},
            new CourseDataEntity(){RowKey="Project III: Mobile apps", Course = "Project III: Mobile apps", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,26))},
            new CourseDataEntity(){RowKey="Enterprise Linux", Course = "Enterprise Linux", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,52))},
            new CourseDataEntity(){RowKey="Windows Server", Course = "Windows Server", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,77))},
            new CourseDataEntity(){RowKey="Computernetwerken IV", Course = "Computernetwerken IV", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="Project III: Systeembeheer", Course = "Project III: Systeembeheer", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="Inleiding Mainframe", Course = "Inleiding Mainframe", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(36,12,0,102))},
            new CourseDataEntity(){RowKey="Mainframe systeembeheer", Course = "Mainframe systeembeheer", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Databanken en transactiesystemen", Course = "Databanken en transactiesystemen", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Batchapplicaties", Course = "Batchapplicaties", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Business Intelligence & Big Data", Course = "Business Intelligence & Big Data", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="e-commerce", Course = "e-commerce", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Business Software", Course = "Business Software", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Project III: e-Business", Course = "Project III: e-Business", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Stage", Course = "Stage", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Bachelorproef", Course = "Bachelorproef", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="i³Talent", Course = "i³Talent", Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))}
        };
    }
}
