using Application.Dtos.Image;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IImageService
    {
        Task<List<GetImageDto>> GetImage(string userId);

        Task  AddImage(AddImageDto image);

        Task<GetImageDto> GetImageById(string ImageId, string userId);

        Task UpdateImage(string Id, UpdateImageDto updateImageDto, string userId);

        Task DeleteImageById(string imageId, string userId);

        Task<string> UploadImage(IFormFile formFileImage, string contentRootPath);
    }
}
