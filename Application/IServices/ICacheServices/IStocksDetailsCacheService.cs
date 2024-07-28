using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices.ICacheServices
{
    public interface IStocksDetailsCacheService
    {
        Task<List<GetStockDetailsDto>> GetStocksDetails();
    }
}
