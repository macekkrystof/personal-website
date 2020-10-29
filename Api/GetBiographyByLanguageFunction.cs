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
using PersonalWebsite.Api.Data;

namespace PersonalWebsite.Api
{
    public class GetBiographyFunction
    {
        private readonly BiographyRepository biographyRepository;
        public GetBiographyFunction(BiographyRepository biographyRepository)
        {
            this.biographyRepository = biographyRepository;
        }

        [FunctionName("GetBiography")]
        public async Task<IActionResult> Run(

            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            string prefferedLanguageCode = req.Query["languageCode"];

            var biography = biographyRepository.GetBiography(prefferedLanguageCode);

            return new JsonResult(biography);
        }
    }
}
