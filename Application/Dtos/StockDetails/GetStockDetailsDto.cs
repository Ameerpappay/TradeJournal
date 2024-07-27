namespace Application.Dtos
{
    public class GetStockDetailsDto
    {
        public string NSECode { get; set; }//2
        public string BSECode { get; set; }//1
        public string StockName { get; set; }//3
        public string Industry { get; set; }//4
        public float ClosingPrice { get; set; }//7
        public float MarketCap { get; set; }//6
        public float WK52 { get; set; }//8
    }
}
