
namespace Application.Dtos.Image
{
    public class AddImageDto
    {
        public string TradeId  { get; set; }

        public string Url { get; set; }

        public Domain.Enum.ImageTag imageTag { get; set; }
    }
}
