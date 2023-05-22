using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/files")]
    public class FilesController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest();
            }
            var folder = Path.Combine(Directory.GetCurrentDirectory(), "Media");
            if(!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            var path = Path.Combine(folder, file.FileName);

            using(var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new
            {
                file = file.FileName,
                path = path,
                size = file.Length
            });
        }

        [HttpGet]
        public async Task<IActionResult> Download(string filename)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Media", filename);
            var provider = new FileExtensionContentTypeProvider();
            if(!provider.TryGetContentType(filename, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes,contentType,Path.GetFileName(filePath));

        }
    }
}
