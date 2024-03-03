using Application.Dtos.Image;
using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class Imageservice : IImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public Imageservice(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddImage(AddImageDto image)
        {
            var newImage = new Image()
            {
                ImageTag = image.imageTag,
                TradeId = image.TradeId
            };
            var addedImage = _unitOfWork.ImageRepository.Add(newImage);

            await _unitOfWork.SaveChangesAsync();

            //return new GetImageDto()
            //{
            //    imageTag = addedImage.
            //}

        }

        public async Task DeleteImageById(int imageId)
        {
            await _unitOfWork.ImageRepository.Delete(imageId);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<List<GetImageDto>> GetImage()
        {
            throw new NotImplementedException();
        }

        public Task<GetImageDto> GetImageById(int ImageId)
        {
            var response = _unitOfWork.ImageRepository.Get(ImageId);
            var image = new GetImageDto();

            image.Id = response.Id;
            image.TradeId = response.Id;

            //return image;
            throw new NotImplementedException();
        }

        public Task UpdateImage(int Id, UpdateImageDto updateImageDto)
        {
            var result = _unitOfWork.ImageRepository.Get(Id);
            //result.

            throw new NotImplementedException();
        }


        public async Task<string> UploadImage(IFormFile formFileImage, string contentRootPath)
        {
            try
            {
                string fileName = DateTime.Now.Ticks+Path.GetFileName(formFileImage.FileName);
                string filePath = Path.Combine(contentRootPath, "TradeImages", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFileImage.CopyToAsync(fileStream);
                }
                return fileName;
            }
            catch (Exception ex)
            {
                return "";
            };

        }
    }
}
