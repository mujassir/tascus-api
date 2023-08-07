using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tascus.Core.Dtos;
using Tascus.Core.Model;

namespace Tascus.Service.Interfaces
{
    public interface IProductionDataServices
    {
        Task<List<ProductResults_Response>> getProductionData(Product_Payload payload);
        Task InsertProductionData(ProductionData product);
    }
}
