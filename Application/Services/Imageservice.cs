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
            var newImage = new TradeImage()
            {
                ImageTag = image.imageTag,
                //   TradeId = image.TradeId
            };
            var addedImage = await _unitOfWork.ImageRepository.Add(newImage);

            await _unitOfWork.SaveChangesAsync();

            //return new GetImageDto()
            //{
            //    imageTag = addedImage.ImageTag,

            //};

        }

        public async Task DeleteImageById(string imageId, string userId)
        {
            await _unitOfWork.ImageRepository.Delete(imageId, userId);
            await _unitOfWork.SaveChangesAsync();
        }

        public Task<List<GetImageDto>> GetTradeImage(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetImageDto> GetTradeImageById(string ImageId, string userId)
        {
            var result = await _unitOfWork.ImageRepository.Get(ImageId, userId);
            var image = new GetImageDto();
            image.Id = result.Identifier.ToString();
            image.Url = result.Url;
            image.imageTag = result.ImageTag;
            return image;
        }

        public Task<List<GetImageDto>> GetTradeImageByTradeId(string userId, string tradeId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTradeImage(string Id, UpdateImageDto updateImageDto, string userId)
        {
            var result = _unitOfWork.ImageRepository.Get(Id, userId);

            throw new NotImplementedException();
        }

        public async Task<string> UploadTradeImage(IFormFile formFileImage, string contentRootPath)
        {
            try
            {
                string fileName = DateTime.Now.Ticks + Path.GetFileName(formFileImage.FileName);
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
        public async Task<string> UploadUserImage(IFormFile formFileImage, string contentRootPath)
        {
            try
            {
                string fileName = DateTime.Now.Ticks + Path.GetFileName(formFileImage.FileName);
                string filePath = Path.Combine(contentRootPath, "UserPhotos", fileName);
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
