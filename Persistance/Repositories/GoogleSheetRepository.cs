using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Persistance.Helpers;

namespace Persistance.Repositories
{
    public class GoogleSheetRepository
    {
        private SheetsService _sheetsService { get; set; }
        const string SPREADSHEET_ID = "143JhAuG7l_tSk5WMR4A1t1YuC-jL3r-DLmzw_WvC_bk";
        const string STOCKPRICE_SHEETNAME = "Items";

        SpreadsheetsResource.ValuesResource _googleSheetValues;

        public GoogleSheetRepository()
        {
            var googleSheetAuth = new GoogleSheetAuth();
            _sheetsService = googleSheetAuth.GetSheetsService();
            _googleSheetValues = _sheetsService.Spreadsheets.Values;
        }



    }
}
