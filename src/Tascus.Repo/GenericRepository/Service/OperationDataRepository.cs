using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Tascus.Repo.Data;
using Tascus.Repo.GenericRepository.Interface;

namespace Tascus.Repo.GenericRepository.Service
{
    public class OperationDataRepository : IOperationDataRepository
    {
        private readonly RepositoryContext _dbContext;
        private readonly IMapper _mapper;

        public OperationDataRepository(RepositoryContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<ProductStatus_Response>> getOperationData(Product_Payload payload)
        {
            if (!Enum.IsDefined(typeof(OperationIDs), payload.Operation_ID))
                throw new Exception("Invalid Operation Id value!");

            var operationData = await _dbContext.OperationData
                .Where(od =>
                    od.Model_Number == payload.Part_Number &&
                    od.Serial_Number == payload.Serial_Number &&
                    od.Operation_ID == payload.Operation_ID)
                .ProjectTo<ProductStatus_Response>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return operationData;
        }

        public async Task UpdateOperationData(OperationData product)
        {
            if (!Enum.IsDefined(typeof(OperationIDs), product.Operation_ID))
                throw new Exception("Invalid Operation Id value!");

            if (!Enum.IsDefined(typeof(Statuses), product.Status))
                throw new Exception("Invalid Status value!");

            if (!Enum.IsDefined(typeof(ResultsEnum), product.Result))
                throw new Exception("Invalid Result value!");

            var operationData = await _dbContext.OperationData.FirstOrDefaultAsync(od =>
            od.Model_Number == product.Model_Number &&
            od.Serial_Number == product.Serial_Number&&
            od.Operation_ID == product.Operation_ID);

            if (operationData != null)
            {
                operationData.Status = product.Status;
                operationData.Result = product.Result;
                _dbContext.Update(operationData);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
