using Microsoft.Azure.Cosmos.Table;
using System.Threading.Tasks;
using PersonalWebsite.Shared.Models;
using PersonalWebsite.Api.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PersonalWebsite.Api.Data
{
    public class BiographyRepository
    {
        private readonly CloudStorageAccount storageAccount;
        public BiographyRepository(CloudStorageAccountFactory cloudStorageAccountFactory)
        {
            storageAccount = cloudStorageAccountFactory.CreateStorageAccount();
        }

        public async Task<bool> SaveBiographyAsync(Biography biography)
        {
            var table = GetCloudTable();
            await table.CreateIfNotExistsAsync();

            if(biography.Id == Guid.Empty)
            {
                biography.Id = Guid.NewGuid();
            }
            var biographyTableModel = new BiographyTableModel(biography);

            try
            {   
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(biographyTableModel);

                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                BiographyTableModel insertedBiography = result.Result as BiographyTableModel;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return false;
            }
        }

        public Biography GetBiography(string preferredLanguageCode)
        {
            var queries = BuildBiographyQueries(preferredLanguageCode);
            var biography = ExecuteQueriesAndGetResult(queries);

            return biography?.GetBiography();
        }
        private CloudTable GetCloudTable()
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            return tableClient.GetTableReference("Biographies");
        }

        private List<string> BuildBiographyQueries(string preferredLanguageCode, string defaultLanguageCode = "en") => new List<string>
            {
                TableQuery.GenerateFilterCondition(nameof(BiographyTableModel.PartitionKey), QueryComparisons.Equal, preferredLanguageCode),
                TableQuery.GenerateFilterCondition(nameof(BiographyTableModel.PartitionKey), QueryComparisons.Equal, defaultLanguageCode),
                TableQuery.GenerateFilterCondition(nameof(BiographyTableModel.PartitionKey), QueryComparisons.NotEqual, ""),
            };

        private BiographyTableModel ExecuteQueriesAndGetResult(List<string> queries)
        {
            var table = GetCloudTable();
            BiographyTableModel biography = null;

            int index = 0;
            do
            {
                biography = table
                    .ExecuteQuery(new TableQuery<BiographyTableModel>()
                    .Where(queries[index]))
                    .FirstOrDefault();

                index++;

            } while (biography == null && index < queries.Count);

            return biography;
        }
    }
}