using StudentNotes.Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentNotes.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/helpers")]
    public class HelpersController : Controller
    {
        private readonly ICloudStorageService _cloudStorageService;

        public HelpersController(ICloudStorageService cloudStorageService)
        {
            this._cloudStorageService = cloudStorageService;
        }

        [HttpPost("file-to-link")]
        [Authorize]
        public async Task<IActionResult> FileToLink()
        {
            var link = String.Empty;
            var file = Request.Form.Files[0];
            using (var stream = file.OpenReadStream())
            {
                link = await this._cloudStorageService.UploadAsync(stream, file.FileName, file.ContentType,
                                                                   "student-notes");
            }

            return Ok(new { link = link });
        }
    }
}
