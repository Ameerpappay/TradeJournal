using Application.Dtos.Excel;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebApi.Controllers
{
    [Route("api/excelSheet-management")]
    [ApiController]
    public class ExcelImportController : ControllerBase
    {
        private IExcelSheetService _excelSheetService;
        public ExcelImportController( IExcelSheetService excelSheetService)
        {
                _excelSheetService = excelSheetService;
        }
        [HttpPost("excel")]
        public async Task< ActionResult> excelImport(IFormFile file)
        {
            if (file == null)
                return BadRequest("No file uploaded.");
                       
                var response = _excelSheetService.ImportExcelSheet(file);
                return Ok("success");           
        }
    }
}
