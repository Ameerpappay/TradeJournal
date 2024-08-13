namespace Application.Dtos
{
    public class GetStockDetailsDto
    {
        public string NSECode { get; set; }//1
        public string BSECode { get; set; }//0
        public string StockName { get; set; }//2
        public string Industry { get; set; }//3
        public float ClosingPrice { get; set; }//6
        public float MarketCap { get; set; }//5
        public float PercentageChange { get; set; }//7
        public float WK52 { get; set; }//8
    }
}
