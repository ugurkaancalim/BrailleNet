using BrailleNet.Core.Environment.Interfaces;
using BrailleNet.Core.Interfaces;
using BrailleNet.Core.Types;
using DocumentFormat.OpenXml.Wordprocessing;
using iText.Forms.Form.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrailleNet.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BrailleToTextController : ControllerBase
    {
        private readonly ITextTranslator _textTranslator;
        private readonly IFileService _fileService;
        public BrailleToTextController(ITextTranslator textTranslator, IFileService fileService)
        {
            _textTranslator = textTranslator;
            _fileService = fileService;
        }

        /// <summary>
        /// This method translates a file content to braille text. 
        /// </summary>
        /// <param name="file">File to translate</param>
        /// <param name="languageCode">ISO 639-1 language code</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Convert(IFormFile file, string languageCode, FileFormat fileFormat)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            if (string.IsNullOrEmpty(languageCode))
                return BadRequest("Parameter is missing.");



            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] data = memoryStream.ToArray();

                var filePath = _fileService.StoreFile(data, file.FileName, out var newFilePath,out var newFileUrl,fileFormat);
                _textTranslator.Translate(filePath, newFilePath, fileFormat);
                return Ok(newFileUrl);
            }

        }
    }
}
