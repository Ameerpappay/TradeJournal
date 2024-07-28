using Application.Dtos;
using Application.Dtos.Trade;
using Application.IRepositories;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.Extensions.Caching.Memory;
using Persistance.Helpers;
using System;

namespace Persistance.Repositories
{
    public class GoogleSheetRepository : IStocksDetailsRepository
    {
        private SheetsService _sheetService { get; set; }
        private GoogleSheetAuth _googleSheetAuth { get; set; }

        const string SPREADSHEET_ID = "1KwKecChnD3-iu7BHUN5_GAUoQ6VuubBHpqRbfW4-MV4";
        const string STOCKPRICE_SHEETNAME = "FullStockList";

        public GoogleSheetRepository(GoogleSheetAuth googleSheetAuth)
        {
            _googleSheetAuth = googleSheetAuth;
            _sheetService = _googleSheetAuth.GetSheetsService();
        }

        public async Task<List<GetStockDetailsDto>> GetStocksDetails()
        {
            var range = $"{STOCKPRICE_SHEETNAME}!A1:Z";
            var request = _sheetService.Spreadsheets.Values.Get(SPREADSHEET_ID, range);
            var response = await request.ExecuteAsync();

            var stocksList = response.Values.Skip(1).Select(row =>
            {
                float marketCap,closingPrice,wk52;
                if (!float.TryParse(row[6]?.ToString(), out marketCap))
                {
                    marketCap = 0; 
                }

                if (!float.TryParse(row[7]?.ToString(), out closingPrice))
                {
                    closingPrice = 0;
                }
                if (!float.TryParse(row[8]?.ToString(), out wk52))
                {
                    wk52 = 0;
                }

                return new GetStockDetailsDto
                {
                    StockName = row[3]?.ToString(),
                    BSECode = row[1]?.ToString(),
                    NSECode = row[2]?.ToString(),
                    Industry = row[2]?.ToString(),
                    MarketCap = marketCap,
                    ClosingPrice=closingPrice,
                    WK52=wk52,                   

                };
            }).ToList();
            return stocksList;
        }
    }
}
