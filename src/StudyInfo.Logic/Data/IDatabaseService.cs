using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace StudyInfo.Logic.Data
{
    public interface IDatabaseService
    {
        Task<T> Get<T>(string id) where T : ITableEntity, new();
        Task<IEnumerable<T>> GetAll<T>() where T : ITableEntity, new();
        Task Insert(ITableEntity entity);
        Task Update(ITableEntity entity);
        Task<bool> Delete<T>(string id) where T : ITableEntity, new();
    }
}
