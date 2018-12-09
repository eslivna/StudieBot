using System.Collections.Generic;
using StudyInfo.ConsoleApp.SampleData;
using StudyInfo.Logic.Data;

namespace StudyInfo.ConsoleApp.StorageEngine
{
    public class StorageProvider
    {
        private List<IDataProcessor> _processors;
        private readonly IDatabaseService _dbservice;

        public StorageProvider()
        {
            _dbservice = new DatabaseService();
            InitializeProcessors();
        }
        private void InitializeProcessors()
        {
            _processors = new List<IDataProcessor> {
                new CourseProcessor(_dbservice, AppliedInformatics.Data)
            };
        }

        public void Process()
        {
            foreach (var processor in _processors)
            {
                processor.Process();
            }
        }
    }
}
