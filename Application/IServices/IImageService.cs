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
        Task<List<GetImageDto>> GetImage();

        Task  AddImage(AddImageDto image);

        Task<GetImageDto> GetImageById(int ImageId);

        Task UpdateImage(int Id, UpdateImageDto updateImageDto);

        Task DeleteImageById(int imageId);

        Task<string> UploadImage(IFormFile formFileImage, string contentRootPath);
    }
}
