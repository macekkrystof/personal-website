using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.IO;
using Azure.Storage.Blobs;

namespace PersonalWebsite.Api
{
    public class UploadImageFunction
    {
        private readonly BlobContainerClient blobContainerClient;
        public UploadImageFunction(BlobContainerClient blobContainerClient)
        {
            this.blobContainerClient = blobContainerClient;
        }

        [FunctionName("UploadImage")]
        public async Task<IActionResult> Run(

            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var formFile = req.Form.Files["file"];
            string fileName = formFile.FileName;
            
            if(Path.GetExtension(fileName) != ".png")
                return new BadRequestResult();

            BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
            using (Stream stream = formFile.OpenReadStream())
            {
               await blobClient.UploadAsync(stream, true);
            }
            
            return new JsonResult(Uri.EscapeUriString($"{blobContainerClient.Uri}/{fileName}"));
        }
    }
}
