using Microsoft.Azure.Cosmos.Table;
using System.Threading.Tasks;
using Shared.Models.Biography;
using PersonalWebsite.Api.Models;
using System;
using System.Linq;

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

        public Biography GetBiographyByLanguageCode(string languageCode)
        {
            var table = GetCloudTable();
            TableQuery<BiographyTableModel> query = new TableQuery<BiographyTableModel>().Where(
                TableQuery.GenerateFilterCondition(nameof(BiographyTableModel.PartitionKey), QueryComparisons.Equal, languageCode));
                
            return table
            .ExecuteQuery<BiographyTableModel>(query)?
            .FirstOrDefault()?
            .GetBiography();
        }
        
        private CloudTable GetCloudTable()
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            return tableClient.GetTableReference("Biographies");
        }
    }
}