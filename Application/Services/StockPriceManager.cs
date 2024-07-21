using Application.Dtos.StockPrice;
using Application.IRepositories;
using Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class StockPriceManager : IStockPriceManager
    {
        IGoogleSheetRepository _sheetRepository;
        public StockPriceManager(IGoogleSheetRepository googleSheetRepository)
        {
            _sheetRepository = googleSheetRepository;           
        }
        public List<GetStockPriceDto> GetStocksPrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public async void ReadStockEntries()
        {
            await _sheetRepository.ReadEntries();
        }
        public GetStockPriceDto GetStockPrice(string stockCode)
        {
            GetStockPriceDto result = _sheetRepository.GetStockByCode(stockCode);
            return result;
        }
    }
}
