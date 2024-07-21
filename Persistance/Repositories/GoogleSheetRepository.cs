using Application.Dtos;
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
        private SheetsService _SheetsService { get; set; }
        private GoogleSheetAuth _GoogleSheetAuth { get; set; }

        const string SPREADSHEET_ID = "1KwKecChnD3-iu7BHUN5_GAUoQ6VuubBHpqRbfW4-MV4";
        const string STOCKPRICE_SHEETNAME = "FullStockList";


        public GoogleSheetRepository(GoogleSheetAuth googleSheetAuth)
        {
            _GoogleSheetAuth = googleSheetAuth;
            _SheetsService = _GoogleSheetAuth.GetSheetsService();
        }

        public async Task<GetStockDetailsDto> GetStockDetails(string code)
        {
            var range = $"{STOCKPRICE_SHEETNAME}!A1:E";
            var request = _SheetsService.Spreadsheets.Values.Get(SPREADSHEET_ID, range);
            var response = await request.ExecuteAsync();
            return new GetStockDetailsDto();
        }

        public async Task<List<GetStockDetailsDto>> GetStocksDetails(List<string> stockCodes)
        {
            throw new NotImplementedException();
        }
    }
}
