using Microsoft.AspNetCore.Mvc;

namespace FileUploadService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : ControllerBase
    {
        private readonly ILogger<FileUploadController> _logger;

        public FileUploadController(ILogger<FileUploadController> logger)
        {
            _logger = logger;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("{userId}/files")]
        public void UploadFiles(string userId)
        {
            _logger.LogInformation("UserId: {0}", userId);
            foreach (var file in Request.Form.Files.ToList())
            {
                _logger.LogInformation("Filename: {0}", file.FileName);
            }
        }
    }
}