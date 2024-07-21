namespace Application.Dtos
{
    public class GetStockDetailsDto
    {
        public string StockCode { get; set; }

        public float StockPrice { get; set; }

        public string StockName { get; set; }

        public float MarketCap { get; set; }
    }
}
