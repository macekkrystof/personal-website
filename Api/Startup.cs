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

            builder.Services.AddSingleton<CloudStorageAccountFactory>((s) => {
                return new CloudStorageAccountFactory(System.Environment.GetEnvironmentVariable("StorageConnectionString"));
            });

            builder.Services.AddSingleton<BiographyRepository>((s) => {
                return new BiographyRepository(s.GetService<CloudStorageAccountFactory>());
            });

        }
    }
}