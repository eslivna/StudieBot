using System;
using System.Collections.Generic;
using StudyInfo.Logic.Data;
using StudyInfo.Logic.Data.Domain;

namespace StudyInfo.ConsoleApp.SampleData
{
    public class CourseProcessor : IDataProcessor
    {
        private readonly IDatabaseService _dbservice;
        private IList<CourseDataEntity> _data;

        public CourseProcessor(IDatabaseService dbservice, IList<CourseDataEntity> data)
        {
            _dbservice = dbservice;
            _data = data;
        }

        public bool Process()
        {
            foreach (var entity in _data)
            {
                try
                {
                    _dbservice.Insert(entity);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine($"Something went wrong while processing {entity.Course} \n {e.Message}");
                }
                Console.WriteLine($"Done with processing {entity.Course} \nHit 'Enter' to close the application");
            }
            return true;
        }
    }
}
