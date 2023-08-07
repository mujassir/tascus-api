using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tascus.Core.Dtos;
using Tascus.Core.Model;

namespace Tascus.Service.Interfaces
{
    public interface IOperationDataService
    {
        Task<List<ProductStatus_Response>> getOperationData(Product_Payload payload);
        Task UpdateOperationData(OperationData product);
    }
}
