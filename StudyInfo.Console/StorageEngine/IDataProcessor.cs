using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace StudyInfo.ConsoleApp.SampleData
{
    public interface IDataProcessor
    {
        bool Process();
    }
}
