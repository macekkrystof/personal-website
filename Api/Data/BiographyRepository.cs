using Microsoft.Azure.Cosmos.Table;
using System.Threading.Tasks;
using Shared.Models.Biography;
using PersonalWebsite.Api.Models;
using System;

namespace PersonalWebsite.Api.Data
{
    public class BiographyRepository
    {
        private readonly CloudStorageAccount storageAccount;
        public BiographyRepository(CloudStorageAccountFactory cloudStorageAccountFactory)
        {
            storageAccount = cloudStorageAccountFactory.CreateStorageAccount();
        }

        public async Task<bool> SaveNewBiographyAsync(Biography biography)
        {
            var table = GetCloudTable();
            await table.CreateIfNotExistsAsync();

            biography.Id = Guid.NewGuid();
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

        private CloudTable GetCloudTable()
        {
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
            return tableClient.GetTableReference("Biographies");
        }
    }
}