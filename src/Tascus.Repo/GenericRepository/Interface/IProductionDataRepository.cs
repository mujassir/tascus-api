using Tascus.Core.Dtos;
using Tascus.Core.Model;

namespace Tascus.Repo.GenericRepository.Interface
{
    public interface IProductionDataRepository
    {
        Task<List<ProductionData>> getProductionData(Production_Payload payload);
        Task InsertProductionData(ProductionData product);
    }
}
