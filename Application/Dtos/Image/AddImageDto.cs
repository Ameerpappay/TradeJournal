﻿
namespace Application.Dtos.Image
{
    public class AddImageDto
    {
        public int TradeId  { get; set; }

        public Domain.Enum.ImageTag imageTag { get; set; }
    }
}
