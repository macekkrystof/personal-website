using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using Newtonsoft.Json;
using PersonalWebsite.Shared.Models;
using PersonalWebsite.Api.Data;
using PersonalWebsite.Api.Authorization;

namespace PersonalWebsite.Api
{
    public class SaveNewBiographyFunction : BaseAuthorizedFunction
    {
        private readonly BiographyRepository biographyRepository;
        public SaveNewBiographyFunction(BiographyRepository biographyRepository, IHttpContextAccessor a) : base(a)
        {
            this.biographyRepository = biographyRepository;
        }

        [RoleAuthorize("Admin")]
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
