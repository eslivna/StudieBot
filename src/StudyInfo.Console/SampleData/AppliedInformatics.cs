﻿using System.Collections.Generic;
using Newtonsoft.Json;
using StudyInfo.Logic.Domain.Course;

namespace StudyInfo.ConsoleApp.SampleData
{
    public static class AppliedInformatics
    {
        public static IList<CourseDataEntity> Data => new List<CourseDataEntity>
        {
            //Courses first year
            new CourseDataEntity(){RowKey="Computerarchitectuur", Course = "Computerarchitectuur", AcademicYear=1, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,18,51))},
            new CourseDataEntity(){RowKey="Computernetwerken I", Course = "Computernetwerken I", AcademicYear=1, Term=2, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,30,64))},
            new CourseDataEntity(){RowKey="OO Programmeren I", Course = "OO Programmeren I",AcademicYear=1, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Analyse I", Course = "Analyse I", AcademicYear=1, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,8,16,51))},
            new CourseDataEntity(){RowKey="OO Ontwerpen I", Course = "OO Ontwerpen I",AcademicYear=1, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,18,18,64))},
            new CourseDataEntity(){RowKey="Databanken I", Course = "Databanken I", AcademicYear=1, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,24,64))},
            new CourseDataEntity(){RowKey="Webapplicaties I", Course = "Webapplicaties I", AcademicYear=1, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,24,51))},
            new CourseDataEntity(){RowKey="Partim Financieel Management", Course = "Partim Financieel Management",AcademicYear=1, Term=2, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,64))},
            new CourseDataEntity(){RowKey="Partim Strategisch Management", Course = "Partim Strategisch Management",AcademicYear=1, Term=2, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,26))},
            new CourseDataEntity(){RowKey="Math4IT", Course = "Math4IT",AcademicYear=1, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,52))},
            new CourseDataEntity(){RowKey="Probleemoplossend denken I", Course = "Probleemoplossend denken I",AcademicYear=1, Term=2, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,77))},
            new CourseDataEntity(){RowKey="Internationale Communicatie I", Course = "Internationale Communicatie I",AcademicYear=1, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="i¹Talent", Course = "i¹Talent",AcademicYear=1, Term=2, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="Projecten-workshops I", Course = "Projecten-workshops I", AcademicYear=1, Term=2,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(36,12,0,102))},
            new CourseDataEntity(){RowKey="OO Programmeren II", Course = "OO Programmeren II",AcademicYear=1, Term=2, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Webapplicaties II", Course = "Webapplicaties II", AcademicYear=1, Term=2,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},

            //Courses second year
            new CourseDataEntity(){RowKey="Bedrijfsmanagement", Course = "Bedrijfsmanagement",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,18,51))},
            new CourseDataEntity(){RowKey="IT2Business", Course = "IT2Business",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,30,64))},
            new CourseDataEntity(){RowKey="Analyse II", Course = "Analyse II", AcademicYear=2, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Onderzoekstechnieken", Course = "Onderzoekstechnieken",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,8,16,51))},
            new CourseDataEntity(){RowKey="Probleemoplossend denken II", Course = "Probleemoplossend denken II",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,18,18,64))},
            new CourseDataEntity(){RowKey="Databanken II", Course = "Databanken II",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,24,64))},
            new CourseDataEntity(){RowKey="Besturingssystemen", Course = "Besturingssystemen",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,24,51))},
            new CourseDataEntity(){RowKey="Internationale Communicatie II", Course = "Internationale Communicatie II", AcademicYear=2, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,64))},
            new CourseDataEntity(){RowKey="i²Talent", Course = "i²Talent",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,26))},
            new CourseDataEntity(){RowKey="OO Programmeren III", Course = "OO Programmeren III",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,52))},
            new CourseDataEntity(){RowKey="Webapplicaties III", Course = "Webapplicaties III",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,77))},
            new CourseDataEntity(){RowKey="OO Ontwerpen II", Course = "OO Ontwerpen II",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="OO Ontwerpen III", Course = "OO Ontwerpen III",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="Webapplicaties IV", Course = "Webapplicaties IV", AcademicYear=2, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(36,12,0,102))},
            new CourseDataEntity(){RowKey="Projecten-workshops II: Programmeren", Course = "Projecten-workshops II: Programmeren",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Computernetwerken II", Course = "Computernetwerken II",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Computernetwerken III", Course = "Computernetwerken III", AcademicYear=2, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Projecten-workshops II: Systeembeheer", Course = "Projecten-workshops II: Systeembeheer",AcademicYear=2, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},

            //Courses third year
            new CourseDataEntity(){RowKey="Analyse III", Course = "Analyse III",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,18,51))},
            new CourseDataEntity(){RowKey="Databanken III", Course = "Databanken III",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,6,30,64))},
            new CourseDataEntity(){RowKey="Internationale Communicatie III", Course = "Internationale Communicatie III",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Artificiële Intelligentie", Course = "Artificiële Intelligentie (TI)",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,8,16,51))},
            new CourseDataEntity(){RowKey="Native apps I", Course = "Native apps I", AcademicYear=3, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,18,18,64))},
            new CourseDataEntity(){RowKey="Native apps II: mobile apps voor Windows", Course = "Native apps II: mobile apps voor Windows",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,24,64))},
            new CourseDataEntity(){RowKey="Native apps II: mobile apps voor iOS", Course = "Native apps II: mobile apps voor iOS",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,24,51))},
            new CourseDataEntity(){RowKey="Web apps", Course = "Web apps", AcademicYear=3, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,64))},
            new CourseDataEntity(){RowKey="Project III: Mobile apps", Course = "Project III: Mobile apps",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,12,26))},
            new CourseDataEntity(){RowKey="Enterprise Linux", Course = "Enterprise Linux", AcademicYear=3, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,52))},
            new CourseDataEntity(){RowKey="Windows Server", Course = "Windows Server",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,48,77))},
            new CourseDataEntity(){RowKey="Computernetwerken IV", Course = "Computernetwerken IV", AcademicYear=3, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="Project III: Systeembeheer", Course = "Project III: Systeembeheer",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(12,0,12,51))},
            new CourseDataEntity(){RowKey="Inleiding Mainframe", Course = "Inleiding Mainframe",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(36,12,0,102))},
            new CourseDataEntity(){RowKey="Mainframe systeembeheer", Course = "Mainframe systeembeheer",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,12,48,65))},
            new CourseDataEntity(){RowKey="Databanken en transactiesystemen", Course = "Databanken en transactiesystemen", AcademicYear=3, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Batchapplicaties", Course = "Batchapplicaties", AcademicYear=3, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Business Intelligence & Big Data", Course = "Business Intelligence & Big Data", AcademicYear=3, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="e-commerce", Course = "e-commerce", AcademicYear=3, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Business Software", Course = "Business Software", AcademicYear=3, Term=1,Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Project III: e-Business", Course = "Project III: e-Business",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Stage", Course = "Stage",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="Bachelorproef", Course = "Bachelorproef",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))},
            new CourseDataEntity(){RowKey="i³Talent", Course = "i³Talent",AcademicYear=3, Term=1, Teacher="Esli Van Acoleyen", StudyTime= JsonConvert.SerializeObject(new StudyTime(0,0,63,64))}
        };
    }
}
