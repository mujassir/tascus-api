using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Tascus.Repo.GenericRepository.Interface;
using Tascus.Service.Interfaces;

namespace Tascus.Service.Services
{
    public class ProductionDataServices : IProductionDataServices
    {
        private readonly IProductionDataRepository _repository;

        public ProductionDataServices(IProductionDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResults_Response>> getProductionData(Product_Payload payload)
        {
            return await _repository.getProductionData(payload);
        }

        public async Task InsertProductionData(ProductionData product)
        {
            await _repository.InsertProductionData(product);
        }
    }
}
