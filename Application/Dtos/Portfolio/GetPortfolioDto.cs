namespace Application.Dtos.Portfolio
{
    public class GetPortfolioDto
    {
        public int PortfolioId { get; set; }
        public string Identifier { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
