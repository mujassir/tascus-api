using AutoMapper;
using AutoMapper.QueryableExtensions;
using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Microsoft.EntityFrameworkCore;
using Tascus.Repo.Data;
using Tascus.Repo.GenericRepository.Interface;

namespace Tascus.Repo.GenericRepository.Service
{
    public class ProductionDataRepository : IProductionDataRepository
    {
        private readonly RepositoryContext _dbContext;
        private readonly IMapper _mapper;
        public ProductionDataRepository(RepositoryContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductResults_Response>> getProductionData(Product_Payload payload)
        {
            if (!Enum.IsDefined(typeof(OperationIDsAll), payload.Operation_ID))
                throw new Exception("Invalid Operation Id value!");

            List<ProductResults_Response> productionData;
            if(payload.Operation_ID != -1)
            {
                productionData = await _dbContext.ProductionData
                .Where(od =>
                    od.Part_Number == payload.Part_Number &&
                    od.Serial_Number == payload.Serial_Number &&
                    od.Operation_ID == payload.Operation_ID)
                .ProjectTo<ProductResults_Response>(_mapper.ConfigurationProvider)
                .ToListAsync();
            }
            else
            {
                productionData = await _dbContext.ProductionData
                .Where(od =>
                    od.Part_Number == payload.Part_Number &&
                    od.Serial_Number == payload.Serial_Number)
                .ProjectTo<ProductResults_Response>(_mapper.ConfigurationProvider)
                .ToListAsync();
            }

            return productionData;
        }

        public async Task InsertProductionData(ProductionData product)
        {
            if (!Enum.IsDefined(typeof(OperationIDs), product.Operation_ID))
                throw new Exception("Invalid Operation Id value!");

            if (!Enum.IsDefined(typeof(Statuses), product.Step_Status))
                throw new Exception("Invalid Status value!");

            if (!Enum.IsDefined(typeof(ResultsEnum), product.Step_Result))
                throw new Exception("Invalid Result value!");
            
            if (product.Date == DateTime.MinValue)
                throw new Exception("Invalid Date value!");

            await _dbContext.ProductionData.AddAsync(product);
            await _dbContext.SaveChangesAsync();

        }
    }
}
