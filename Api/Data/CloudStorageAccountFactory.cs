using System;
using Microsoft.Azure.Cosmos.Table;

namespace PersonalWebsite.Api.Data
{
    public class CloudStorageAccountFactory
    {
        private readonly string storageConnectionString;
        public CloudStorageAccountFactory(string storageConnectionString)
        {
            this.storageConnectionString = storageConnectionString;
        }
        
        public CloudStorageAccount CreateStorageAccount()
        {
            CloudStorageAccount storageAccount;
            try
            {
                storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the application.");
                throw;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid storage account information provided. Please confirm the AccountName and AccountKey are valid in the app.config file - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            return storageAccount;
        }
    }
}