using Application.Dtos.Excel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IExcelSheetRepository
    {
        public Task<bool> UploadExcelSheetData(string path);

    }
}
