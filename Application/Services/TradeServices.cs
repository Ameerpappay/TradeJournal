using Application.Dtos;
using Application.Dtos.Holdings;
using Application.Dtos.Image;
using Application.Dtos.Portfolio;
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
        IStrategyService _strategyService;

        public TradeServices(IUnitOfWork unitOfWork, IImageService imageService, IStrategyService strategyService, IHoldingsServices holdingsServices, IPortfolioServices portfolioService)
        {
            _unitOfWork = unitOfWork;
            _imageService = imageService;
            _holdingsService = holdingsServices;
            _portfolioService = portfolioService;
            _strategyService = strategyService;
        }
        public async Task<GetTradeDto> AddTrade(AddTradeDto trade, string contentRoot, string userId)
        {
            GetPortfolioDto selectedPortfolio = await _unitOfWork.PortfolioRepository.SelectedPortfolio(userId);
            
            AddHoldingsDto addHoldingsDto = new AddHoldingsDto
            {
                Code = trade.Code,
                BuyPrice = trade.Price,
                TrailingStoploss = trade.StopLoss,
                Quantity = trade.Quantity,
                PortfolioId = selectedPortfolio.PortfolioId
            };

            GetHoldingsDto getHoldingsDto = await _holdingsService.AddHoldings(addHoldingsDto, userId);

            DateTime localDateTime = DateTime.SpecifyKind(trade.EntryDate, DateTimeKind.Local);
            DateTime utcDateTime = localDateTime.ToUniversalTime();

            int strategyId = await this._strategyService.GetStrategyId(trade.StrategyId, userId);

            var newTrade = new Trade()
            {
                Action = trade.Action,
                HoldingsId = getHoldingsDto.Id,
                Price = trade.Price,
                EntryDate = utcDateTime,
                Quantity = trade.Quantity,
                StopLoss = trade.StopLoss,
                StrategyId = strategyId,
                Description = trade.Description,
                CreatedByUserId = userId,
            };

            TradeImage tradeImage = new TradeImage();

            if(trade.Images != null)
            {
                foreach (var image in trade.Images)
                {
                    var imageUrl = await _imageService.UploadTradeImage(image.ImageFile, contentRoot);
                    tradeImage.ImageTag = (ImageTag)image.ImageTag;
                    tradeImage.Url = imageUrl;
                    tradeImage.CreatedByUserId = userId;
                    newTrade.Images = new List<TradeImage> { tradeImage };
                }
            }
          

            var addedTrade = await _unitOfWork.TradeRepository.Add(newTrade);
            await _unitOfWork.SaveChangesAsync();

            return new GetTradeDto()
            {
                Id = addedTrade.Identifier.ToString(),
                HoldingsId = getHoldingsDto.Identifier.ToString(),
                EntryDate = addedTrade.EntryDate,
                Quantity = addedTrade.Quantity,
                StopLoss = addedTrade.StopLoss,
                //  StrategyId = strategyId,
                Description = addedTrade.Description,
            };

            //TradeImage tradeImg = new TradeImage();

            //foreach (var image in trade.Images)
            //{
            //    var imageUrl = await _imageService.UploadImage(image.ImageFile, contentRoot);
            //    tradeImg.ImageTag = (ImageTag)image.ImageTag;
            //    tradeImg.Url = imageUrl;
            //    tradeImg.CreatedByUserId = userId;
            //    tradeImg.TradeId=addedTrade.Identifier.ToString();
            //}

            //var addedImage = await _unitOfWork.ImageRepository.Add(tradeImg);
            //await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteTradeById(string tradeId, string userId)
        {
            await _unitOfWork.TradeRepository.Delete(tradeId, userId);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<GetTradeDto> GetTradeById(string tradeId, string userID)
        {
            var result = await _unitOfWork.TradeRepository.Get(tradeId, userID);
            var trade = new GetTradeDto();
            trade.Id = result.Identifier.ToString();
            trade.EntryDate = result.EntryDate;
            trade.Quantity = result.Quantity;
            trade.Price = result.Price;
            trade.Description = result.Description;
            trade.StopLoss = result.StopLoss;
            trade.StrategyId = result.Strategy.Identifier.ToString();
            trade.Action = (TradeAction.SELL.Equals(result.Action) ? TradeAction.SELL : TradeAction.BUY);
            trade.HoldingsId = result.Holdings.Identifier.ToString();
            trade.holding = new GetHoldingsDto
            {
                Code = result.Holdings.StockCode,
                Identifier = result.Holdings.Identifier.ToString(),
                Quantity = result.Holdings.Quantity,
                BuyPrice = result.Holdings.BuyPrice,
                TrailingStoploss = result.Holdings.TrailingStoploss,
            };
            trade.Images = result.Images.Select(x => new GetImageDto
            {
                Id = x.Identifier.ToString(),
                TradeId = x.Trade.Identifier.ToString(),
                imageTag = x.ImageTag,
                Url = x.Url,

            }).ToList();

            return trade;
        }

        public async Task<List<GetTradeDto>> GetTrades(string userId)
        {
            GetPortfolioDto selectedPortfolio = await _unitOfWork.PortfolioRepository.SelectedPortfolio(userId);

            var result = await _unitOfWork.TradeRepository.Get(userId,selectedPortfolio.PortfolioId);
            var trades = result.Select(t => new GetTradeDto
            {
                Id = t.Identifier.ToString(),
                HoldingsId = t.Holdings.Identifier.ToString(),
                EntryDate = t.EntryDate,
                StopLoss = t.StopLoss,
                Quantity = t.Quantity,
                Price = t.Price,
                Description = t.Description,
                Code = t.Holdings.StockCode,
                StrategyId = t.Strategy.Identifier.ToString(),
              Action=t.Action,
            }).ToList();

            return trades;
        }

        public async Task<List<GetTradeDto>> GetTradesByHolidingID(string userId, string holdingId)
        {
            var result = await _unitOfWork.TradeRepository. GetTradesByHolidingID(userId, holdingId);
            var trades = result.Select(t => new GetTradeDto
            {
                HoldingsId = t.HoldingsId,
                EntryDate = t.EntryDate,
                StopLoss = t.StopLoss,
                Quantity = t.Quantity,
                Price = t.Price,
                Description = t.Description,
                StrategyId = t.StrategyId,
            }).ToList();
            return trades;
        }

        public async Task UpdateTrade(string TradeId, UpdateTradeDto trade, string userId)
        {
            var resultTrade = await _unitOfWork.TradeRepository.Get(TradeId, userId);
            var resultHolding=await _unitOfWork.HoldingsRepository.Get(trade.HoldingsId,userId);

            int strategyId = await this._strategyService.GetStrategyId(trade.StrategyId, userId);

            resultHolding.BuyPrice = ((resultHolding.BuyPrice *resultHolding.Quantity)-(resultTrade.Price*resultTrade.Quantity)+(trade.Quantity*trade.Price))
                                                        /( resultHolding.Quantity - resultTrade.Quantity + trade.Quantity);
            resultHolding.Quantity = resultHolding.Quantity -resultTrade.Quantity+ trade.Quantity;
            resultHolding.TrailingStoploss = trade.StopLoss;
            _unitOfWork.HoldingsRepository.Update(resultHolding);

            DateTime localDateTime = DateTime.SpecifyKind(trade.EntryDate, DateTimeKind.Local);
            DateTime utcDateTime = localDateTime.ToUniversalTime();

            resultTrade.StopLoss = trade.StopLoss;
            resultTrade.Quantity = trade.Quantity;
            resultTrade.EntryDate = utcDateTime;
            resultTrade.Price = trade.Price;
            resultTrade.Description = trade.Description;
            resultTrade.StrategyId = strategyId;

            _unitOfWork.TradeRepository.Update(resultTrade);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
