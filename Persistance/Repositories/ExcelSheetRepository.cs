using Application.Dtos.Excel;
using Application.IRepositories;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using OfficeOpenXml;

namespace Persistance.Repositories
{
    public class ExcelSheetRepository : GenericRepository<Portfolio>, IExcelSheetRepository
    {
        TradeJournalDataContext _dbContext;

        public ExcelSheetRepository(TradeJournalDataContext context) : base(context)
        {
            _dbContext = context;
        }


        public Task<bool> UploadExcelSheetData(string filePath)
        {
          
            var trades = ReadTradesFromExcel(filePath);
         //   _tradeService.ImportTrades(trades);

            throw new NotImplementedException();
        }

        public List<Trade> ReadTradesFromExcel(string filePath)
        {
            var trades = new List<Trade>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;

                for (int row = 2; row <= rowCount; row++)
                {
                    var trade = new Trade
                    {
                        HoldingsId = int.Parse(worksheet.Cells[row, 1].Text),
                        Price = decimal.Parse(worksheet.Cells[row, 2].Text),
                        Action = (TradeAction)Enum.Parse(typeof(TradeAction), worksheet.Cells[row, 3].Text),
                        EntryDate = DateTime.Parse(worksheet.Cells[row, 4].Text),
                        Quantity = decimal.Parse(worksheet.Cells[row, 5].Text),
                        StopLoss = decimal.Parse(worksheet.Cells[row, 6].Text),
                        StrategyId = int.Parse(worksheet.Cells[row, 7].Text),
                        Description = worksheet.Cells[row, 8].Text
                    };
                    trades.Add(trade);
                }
            }

            return trades;
        }

    }
}
