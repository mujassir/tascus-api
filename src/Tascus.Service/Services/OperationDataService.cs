using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Tascus.Repo.GenericRepository.Interface;
using Tascus.Service.Interfaces;

namespace Tascus.Service.Services
{
    public class OperationDataService : IOperationDataService
    {
        private readonly IOperationDataRepository _repository;

        public OperationDataService(IOperationDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductStatus_Response>> getOperationData(Product_Payload payload)
        {
            return await _repository.getOperationData(payload);
        }

        public async Task UpdateOperationData(OperationData product)
        {
            await _repository.UpdateOperationData(product);
        }
    }
}
