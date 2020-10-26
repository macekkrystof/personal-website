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
using Shared.Models.Biography;
using PersonalWebsite.Api.Data;

namespace PersonalWebsite.Api
{
    public class GetBiographyByLanguageFunction
    {
        private readonly BiographyRepository biographyRepository;
        public GetBiographyByLanguageFunction(BiographyRepository biographyRepository)
        {
            this.biographyRepository = biographyRepository;
        }

        [FunctionName("GetBiographyByLanguage")]
        public async Task<IActionResult> Run(

            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string languageCode = req.Query["languageCode"];

            var biography = biographyRepository.GetBiographyByLanguageCode(languageCode);

            return new JsonResult(biography);
        }
    }
}
