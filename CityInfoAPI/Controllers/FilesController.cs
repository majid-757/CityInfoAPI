using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfoAPI.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private FileExtensionContentTypeProvider fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            this.fileExtensionContentTypeProvider = fileExtensionContentTypeProvider;
        }



        [HttpGet("{fileId}")]
        public ActionResult GetFiles(string fileId)
        {
            var pathToFile = "1.rar";
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);

            if (!fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
