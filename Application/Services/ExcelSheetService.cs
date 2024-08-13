using Application.Dtos.Excel;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ExcelSheetService : IExcelSheetService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExcelSheetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<bool> ImportExcelSheet(IFormFile file)
        {
           string filePath = file.FileName;
            var filePatmh = Path.Combine(Directory.GetCurrentDirectory(), filePath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            _unitOfWork.ExcelSheetRepository.UploadExcelSheetData(filePatmh);
            throw new NotImplementedException();
        }
    }
}
