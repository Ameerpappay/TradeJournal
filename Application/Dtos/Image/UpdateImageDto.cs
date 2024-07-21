namespace Application.Dtos.Image
{
    public class UpdateImageDto
    {
        public int TradeId { get; set; }

        public Domain.Enum.ImageTag imageTag { get; set; }
    }
}
