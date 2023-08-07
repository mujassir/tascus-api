using Microsoft.AspNetCore.Mvc;
using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Tascus.Service.Interfaces;
using Tascus.Service.Services;

namespace Tascus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductResultsController : Controller
    {
        private readonly IProductionDataServices _service;

        public ProductResultsController(IProductionDataServices service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Product_Payload payload)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var operationData = await _service.getProductionData(payload);
                return Ok(operationData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductionData product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _service.InsertProductionData(product);
                return Ok(new { Message = "Product Result Created Successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
