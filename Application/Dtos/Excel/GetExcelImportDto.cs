using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Excel
{
    public class GetExcelImportDto
    {
        public IFormFile ExcelFile { get; set; }

    }
}
