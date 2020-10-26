using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using PersonalWebsite.Api.Data;

[assembly: FunctionsStartup(typeof(PersonalWebsite.Api.Startup))]


namespace PersonalWebsite.Api
{
    public class Startup : FunctionsStartup
    {
         public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;
            var storageConnectionString = System.Environment.GetEnvironmentVariable("StorageConnectionString");
            builder.Services.AddSingleton<CloudStorageAccountFactory>((s) => {
                return new CloudStorageAccountFactory(storageConnectionString);
            });

            builder.Services.AddSingleton<BiographyRepository>((s) => {
                return new BiographyRepository(s.GetService<CloudStorageAccountFactory>());
            });
            
            builder.Services.AddSingleton<BlobContainerClient>((s) => {
                var blobServiceClient = new BlobServiceClient(storageConnectionString);
                return blobServiceClient.GetBlobContainerClient("personalwebsiteblob");
            });

        }
    }
}