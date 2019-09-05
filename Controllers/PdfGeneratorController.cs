using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PDF_API.Api.Controllers
{
    [Route("api/pdf")]
    [ApiController]
    public class PdfGeneratorController : Controller
    {
        private IConverter _converter;
 
        public PdfGeneratorController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet]
        [Route("create")]
        public IActionResult CreatePDF(pageSettings settings) {
        
            try 
            {
                var globalSettings = new GlobalSettings
                {
                        // ColorMode = ColorMode.Color,
                        Orientation = Orientation.Landscape,
                        PaperSize = PaperKind.A3,
                        DocumentTitle = "PDF Report",
                        Out = settings.localSave
                };
                var objectSettings = new ObjectSettings
                {
                    // HtmlContent = TemplateGenerator.GetHTMLString(),
                    PagesCount = true,
                    Page = settings.page,
                    UseExternalLinks = true,
                    UseLocalLinks = true
                };

                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                _converter.Convert(doc);
                return Ok("Successfully created PDF document.");
            }
            catch(System.Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Construction of PDF fail");
            }
        }

        [HttpGet]
        [Route("download")]
        public IActionResult DownloadPDF(pageSettings settings) {
        
            try 
            {
                var globalSettings = new GlobalSettings
                {
                        Orientation = Orientation.Landscape,
                        PaperSize = PaperKind.A3,
                        DocumentTitle = "PDF Report",
                        Out = settings.localSave
                };
                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    Page = settings.page,
                    UseExternalLinks = true,
                    UseLocalLinks = true
                };

                var doc = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };
                var file = _converter.Convert(doc);
                return File(file, "application/pdf", "File.pdf");
            }
            catch(System.Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Construction of PDF fail");
            }
        }
    }
}