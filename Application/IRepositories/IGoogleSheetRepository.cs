using Application.Dtos.StockPrice;

namespace Application.IRepositories
{
    public interface IGoogleSheetRepository
    {
        public Task< IList<IList<object>> >ReadEntries();

        public GetStockPriceDto GetStockByCode(string code);

    }
}
