using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Helpers
{
    public class GoogleSheetAuth
    {
        private SheetsService _sheetsService { get; set; }
        const string APPLICATION_NAME = "trade_journal";
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };

        public SheetsService GetSheetsService()
        {
            var credential = GetCredentialsFromFile();
            _sheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = APPLICATION_NAME
            });

            return _sheetsService;
        }
        private GoogleCredential GetCredentialsFromFile()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }
            return credential;
        }
    }
}
