using Tascus.Core.Dtos;
using Tascus.Core.Model;

namespace Tascus.Repo.GenericRepository.Interface
{
    public interface IProductionDataRepository
    {
        Task<List<ProductResults_Response>> getProductionData(Product_Payload payload);
        Task InsertProductionData(ProductionData product);
    }
}
