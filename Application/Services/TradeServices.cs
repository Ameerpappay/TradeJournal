using Application.Dtos;
using Application.Dtos.Trade;
using Application.IServices;
using Domain.Entities;
using Domain.Enum;

namespace Application.Services
{
    public class TradeServices : ITradeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageService _imageService;
        public TradeServices(IUnitOfWork unitOfWork, IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
        }
        public async Task<GetTradeDto> AddTrade(AddTradeDto trade, string contentRoot)
        {
            var newTrade = new Trade()
            {
                Code = trade.Code,
                Price = trade.Price,
                EntryDate = trade.EntryDate,
                Quantity = trade.Quantity,
                StopLoss = trade.StopLoss,
                StrategyId = trade.StrategyId,
                Narration = trade.Narration,
            };

            foreach (var image in trade.Images)
            {
                var imageUrl =await  _imageService.UploadImage(image.Image, contentRoot);
                newTrade.Images.Add(new Image
                {
                    ImageTag =(ImageTag) image.ImageTag,
                    ImageUrl = imageUrl
                });
            }

            var addedTrade = await _unitOfWork.TradeRepository.Add(newTrade);

            await _unitOfWork.SaveChangesAsync();

            return new GetTradeDto()
            {
                Id = addedTrade.Id,
                Code = addedTrade.Code,
                Price = addedTrade.Price,
                EntryDate = addedTrade.EntryDate,
                Quantity = addedTrade.Quantity,
                StopLoss = addedTrade.StopLoss,
                StrategyId = addedTrade.StrategyId,
                Narration = addedTrade.Narration,
            };
        }

        public async Task DeleteTradeById(int tradeId)
        {
            await _unitOfWork.TradeRepository.Delete(tradeId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetTradeDto> GetTradeById(int tradeId)
        {
            var result = await _unitOfWork.TradeRepository.Get(tradeId);

            var trade = new GetTradeDto();
            trade.Id = result.Id;
            trade.Code = result.Code;
            trade.EntryDate = result.EntryDate;
            trade.Quantity = result.Quantity;
            trade.Price = result.Price;
            trade.Narration = result.Narration;
            trade.StopLoss = result.StopLoss;
            trade.StrategyId = result.StrategyId;

            return trade;
        }

        public async Task<List<GetTradeDto>> GetTrades()
        {
            var result = await _unitOfWork.TradeRepository.Get();

            var trades = result.Select(t => new GetTradeDto
            {
                Id = t.Id,
                Code = t.Code,
                EntryDate = t.EntryDate,
                StopLoss = t.StopLoss,
                Quantity = t.Quantity,
                Price = t.Price,
                Narration = t.Narration,
                StrategyId = t.StrategyId,
            }).ToList();

            return trades;
        }

        public async Task UpdateTrade(int Id, UpdateTradeDto trade)
        {
            var result = await _unitOfWork.TradeRepository.Get(Id);
            result.Code = trade.Code;
            result.StopLoss = trade.StopLoss;
            trade.Quantity = trade.Quantity;
            trade.EntryDate = trade.EntryDate;
            result.Price = trade.Price;
            result.Narration = trade.Narration;
            result.StrategyId = trade.StrategyId;

            await _unitOfWork.TradeRepository.Update(result);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
