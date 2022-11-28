using FileUploadService.Responses;
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

        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            return Ok(new TestResponse {
                Message = "service ready"
            });
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
            foreach (var key in Request.Form.Keys)
            {
                _logger.LogInformation("Key: {0}, Value: {1}", key, Request.Form[key]);
            }
        }
    }
}