using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using Azure;
using Azure.Storage.Blobs;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using PersonalWebsite.Shared.Models;
using PersonalWebsite.Api.Data;

namespace PersonalWebsite.Api
{
    public class SaveNewBiographyFunction
    {
        private readonly BiographyRepository biographyRepository;
        public SaveNewBiographyFunction(BiographyRepository biographyRepository)
        {
            this.biographyRepository = biographyRepository;
        }

        [FunctionName("SaveNewBiography")]
        public async Task<IActionResult> Run(

            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var biography = JsonConvert.DeserializeObject<Biography>(requestBody); 

            var result = await biographyRepository.SaveBiographyAsync(biography);

            if(result)
                return new OkResult();

            return new BadRequestResult();
        }
    }
}
