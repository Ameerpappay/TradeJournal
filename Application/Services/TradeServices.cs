using Application.Dtos;
using Application.Dtos.Holdings;
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
        private IHoldingsServices _holdingsService;
        IPortfolioServices _portfolioService;
            public TradeServices(IUnitOfWork unitOfWork, IImageService imageService,IHoldingsServices holdingsServices,IPortfolioServices portfolioService )
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _holdingsService = holdingsServices;
            _portfolioService = portfolioService;
        }
        public async Task<GetTradeDto> AddTrade(AddTradeDto trade, string contentRoot,string userId)
        {
            int portfolioId = await this._portfolioService.GetPortfolioId(trade.PortfolioId, userId);

            AddHoldingsDto addHoldingsDto = new AddHoldingsDto
            {
                Code = trade.Code,
                BuyPrice=trade.Price,
                TrailingStoploss=trade.StopLoss,
                Quantity=trade.Quantity,
                PortfolioId=portfolioId
            };

            GetHoldingsDto getHoldingsDto= await _holdingsService.AddHoldings(addHoldingsDto, userId);


            DateTime localDateTime = DateTime.SpecifyKind(trade.EntryDate, DateTimeKind.Local);
            DateTime utcDateTime = localDateTime.ToUniversalTime();

            var newTrade = new Trade()
            {
                HoldingsId = getHoldingsDto.Id,
                Price = trade.Price,
                EntryDate = utcDateTime,
            Quantity = trade.Quantity,
                StopLoss = trade.StopLoss,
                StrategyId = trade.StrategyId,
                Description = trade.Narration,
                CreatedByUserId=userId,
            };

            foreach (var image in trade.Images)
            {
                var imageUrl =await  _imageService.UploadImage(image.Image, contentRoot);
                newTrade.Images.Add(new TradeImage
                {
                    ImageTag =(ImageTag) image.ImageTag,
                    Url = imageUrl
                });
            }

            var addedTrade = await _unitOfWork.TradeRepository.Add(newTrade);

            await _unitOfWork.SaveChangesAsync();

            return new GetTradeDto()
            {
                Id = addedTrade.Id,
                HoldingsId= addedTrade.HoldingsId,
                EntryDate = addedTrade.EntryDate,
                Quantity = addedTrade.Quantity,
                StopLoss = addedTrade.StopLoss,
                StrategyId = addedTrade.StrategyId,
                Narration = addedTrade.Description,
            };
        }

        public async Task DeleteTradeById(string tradeId, string userId)
        {
            await _unitOfWork.TradeRepository.Delete(tradeId, userId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetTradeDto> GetTradeById(string tradeId, string userID)
        {
            var result = await _unitOfWork.TradeRepository.Get(tradeId,userID);

            var trade = new GetTradeDto();
            trade.Id = result.Id;
            //trade.Code = result.Code;
            trade.EntryDate = result.EntryDate;
            trade.Quantity = result.Quantity;
            trade.Price = result.Price;
            trade.Narration = result.Description;
            trade.StopLoss = result.StopLoss;
            trade.StrategyId = result.StrategyId;

            return trade;
        }

        public async Task<List<GetTradeDto>> GetTrades(string userId)
        {
            var result = await _unitOfWork.TradeRepository.Get(userId);

            var trades = result.Select(t => new GetTradeDto
            {
                Id = t.Id,
                //Code = t.Code,
                EntryDate = t.EntryDate,
                StopLoss = t.StopLoss,
                Quantity = t.Quantity,
                Price = t.Price,
                Narration = t.Description,
                StrategyId = t.StrategyId,
            }).ToList();

            return trades;
        }

        public async Task UpdateTrade(string Id, UpdateTradeDto trade, string userId)
        {
            var result = await _unitOfWork.TradeRepository.Get(Id,userId);
            //result.Code = trade.Code;
            result.StopLoss = trade.StopLoss;
            trade.Quantity = trade.Quantity;
            trade.EntryDate = trade.EntryDate;
            result.Price = trade.Price;
            result.Description = trade.Narration;
            result.StrategyId = trade.StrategyId;

            _unitOfWork.TradeRepository.Update(result);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
