using Application.Dtos.Image;
using Microsoft.AspNetCore.Http;

namespace Application.IServices
{
    public interface IImageService
    {
        Task<List<GetImageDto>> GetTradeImage(string userId);

        Task<List<GetImageDto>> GetTradeImageByTradeId(string userId, string tradeId);

        Task AddImage(AddImageDto image);

        Task<GetImageDto> GetTradeImageById(string ImageId, string userId);

        Task UpdateTradeImage(string Id, UpdateImageDto updateImageDto, string userId);

        Task DeleteImageById(string imageId, string userId);

        Task<string> UploadTradeImage(IFormFile formFileImage, string contentRootPath);
        Task<string> UploadUserImage(IFormFile formFileImage, string contentRootPath);

    }
}
