using Tascus.Core.Dtos;
using Tascus.Core.Model;

namespace Tascus.Repo.GenericRepository.Interface
{
    public interface IOperationDataRepository
    {
        Task<List<OperationData>> GetOperationData(Production_Payload payload);
        Task UpdateOperationData(OperationData product);
    }
}
