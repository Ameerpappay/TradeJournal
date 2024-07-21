namespace Application.Dtos.Image
{
    public class GetImageDto
    {
        public string Id { get; set; }

        public string TradeId { get; set; }

        public string Url { get; set; }

        public Domain.Enum.ImageTag imageTag { get; set; }
    }
}
