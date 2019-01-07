using Microsoft.WindowsAzure.Storage.Table;

namespace StudyInfo.Logic.Domain.Course
{
    /// <summary>
    /// The CourseDataEntity class
    /// Contains all the properties that correspond to the columns in a tabel from Table Storage
    /// <see cref="https://docs.microsoft.com/en-us/azure/cosmos-db/table-storage-how-to-use-dotnet#add-an-entity-to-a-table"/>
    /// </summary>
    public class CourseDataEntity : TableEntity
    {
        public CourseDataEntity()
        {
            PartitionKey = nameof(CourseDataEntity);
        }

        public CourseDataEntity(string course)
        {
            PartitionKey = nameof(CourseDataEntity);
            RowKey = course;
            Course = course;
        }

        public string Course { get; set; }
        public string Teacher { get; set; }
        public int StudyLoad { get; set; }
        public string StudyTime { get; set; }
        public int AcademicYear { get; set; }
        public int Term { get; set; }
    }
}
