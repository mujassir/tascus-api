using Tascus.Core.Dtos;
using Tascus.Core.Model;

namespace Tascus.Repo.GenericRepository.Interface
{
    public interface IOperationDataRepository
    {
        Task<List<ProductStatus_Response>> getOperationData(Product_Payload payload);
        Task UpdateOperationData(OperationData product);
    }
}
