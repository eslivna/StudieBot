using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using StudyInfo.Logic.Infrastructure;

namespace StudyInfo.Logic.Data
{
    /// <summary>
    /// The DatabaseService
    /// Contains all methods for performing database actions
    /// </summary>
    public class DatabaseService : IDatabaseService
    {
        private static readonly TableStorageConfiguration Config = TableStorageConfiguration.Resolve();

        private CloudTable GetTable()
        {
            var storageAccount = CloudStorageAccount.Parse(Config.ConnectionString);
            return storageAccount.CreateCloudTableClient().GetTableReference(Constants.TableName);
        }

        public async Task<T> Get<T>(string id) where T : ITableEntity, new()
        {
            try
            {
                var table = GetTable();
                var retrieveOperation = TableOperation.Retrieve<T>(typeof(T).Name, id);
                var retrievedResult = await table.ExecuteAsync(retrieveOperation);
                return (T)retrievedResult.Result;
            }
            catch (Exception e)
            {
                throw new Exception("Entity could not be retrieved. " + e.Message);
            }
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : ITableEntity, new()
        {
            var table = GetTable();
            await table.CreateIfNotExistsAsync();
            var query = new TableQuery<T>();

            // Print the fields for each customer.
            TableContinuationToken token = null;
            var result = new List<T>();
            do
            {
                var resultSegment = await table.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                foreach (var entity in resultSegment.Results)
                {
                    result.Add(entity);
                }
            } while (token != null);
            return result;
        }

        public async Task Insert(ITableEntity entity)
        {
            try
            {
                var table = GetTable();
                await table.CreateIfNotExistsAsync();
                var insertOperation = TableOperation.Insert(entity);
                await table.ExecuteAsync(insertOperation);
            }
            catch (Exception e)
            {
                throw new Exception("Entity could not be inserted. " + e.Message);
            }
        }

        public async Task Update(ITableEntity entity)
        {
            try
            {
                var table = GetTable();
                //Only properties with non-null values will be updated by the Merge Entity operation
                var updateOperation = TableOperation.Merge(entity);
                await table.ExecuteAsync(updateOperation);
            }
            catch (Exception e)
            {
                throw new Exception("Entity could not be updated." + e.Message);
            }
        }

        public async Task<bool> Delete<T>(string id) where T : ITableEntity, new()
        {
            var table = GetTable();
            var deleteEntity = Get<T>(id).Result;

            // Create the Delete TableOperation.
            if (deleteEntity != null)
            {
                var deleteOperation = TableOperation.Delete(deleteEntity);
                // Execute the operation.
                await table.ExecuteAsync(deleteOperation);
                return true;
            }
            return false;
        }
    }
}
