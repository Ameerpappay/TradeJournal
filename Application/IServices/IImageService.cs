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

        Task<GetImageDto> GetImageById(int ImageId, string userId);

        Task UpdateImage(int Id, UpdateImageDto updateImageDto, string userId);

        Task DeleteImageById(int imageId, string userId);

        Task<string> UploadImage(IFormFile formFileImage, string contentRootPath);
    }
}
