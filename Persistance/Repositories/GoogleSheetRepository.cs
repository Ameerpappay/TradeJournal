using Application.Dtos.StockPrice;
using Application.IRepositories;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Microsoft.Extensions.Caching.Memory;
using Persistance.Helpers;
using System.Xml.Linq;
//using System.Runtime.Caching;


namespace Persistance.Repositories
{
    public class GoogleSheetRepository:IGoogleSheetRepository
    {
        private SheetsService _sheetsService { get; set; }
        const string SPREADSHEET_ID = "143JhAuG7l_tSk5WMR4A1t1YuC-jL3r-DLmzw_WvC_bk";
        const string STOCKPRICE_SHEETNAME = "Items";

        private MemoryCache _cache;
        private TimeSpan _cacheDuration = TimeSpan.FromMinutes(30);
        SpreadsheetsResource.ValuesResource _googleSheetValues;

        public GoogleSheetRepository()
        {
            var googleSheetAuth = new GoogleSheetAuth();
            _sheetsService = googleSheetAuth.GetSheetsService();
            _googleSheetValues = _sheetsService.Spreadsheets.Values;         
        }

        public async Task< IList<IList<object>> >ReadEntries()
        {
            string range = STOCKPRICE_SHEETNAME + "!A:";
            string cacheKey = "GoogleSheetData_FullSheet";

            if (_cache == null)
            {
                var request = _googleSheetValues.Get(SPREADSHEET_ID, range);
                //  var response = request.Execute();
                //   _cache.Set(cacheKey, response.Values, DateTimeOffset.UtcNow.Add(_cacheDuration));

                try
                {
                    var response = request.Execute();
                    _cache.Set(cacheKey, response.Values, DateTimeOffset.UtcNow.Add(_cacheDuration));

                    return response.Values;
                }
                catch (Google.GoogleApiException ex)
                {
                    if (ex.HttpStatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        Console.WriteLine("Error: Forbidden access to the Google Sheets API. Ensure proper permissions and credentials.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                    throw; // Re-throw the exception after handling
                }

                //return response.Values;
            }
            else
            {
                return (IList<IList<object>>)_cache.Get(cacheKey);
            }
        }     

        public GetStockPriceDto GetStockByCode(string code)
        {
            if (_cache.TryGetValue("Items", out IList<IList<object>> cachedItems))
            {
                //    return cachedItems;
                foreach (var item in cachedItems)
                {
                    if (item.Count > 0 && item[0].ToString() == code) // Assuming name is in the first column
                    {
                        GetStockPriceDto priceDto = new GetStockPriceDto{
                            StockCode = item[0].ToString(),
                            StockPrice =float.Parse( item[1].ToString())

                        };
                        return priceDto;
                    }
                }
            }
            return null;
        }
    }
}
