using Microsoft.AspNetCore.Mvc;
using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Tascus.Service.Interfaces;
using Tascus.Service.Services;

namespace Tascus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductStatusController : Controller
    {
        private readonly IOperationDataService _service;

        public ProductStatusController(IOperationDataService service)
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

                var operationData = await _service.getOperationData(payload);
                return Ok(operationData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task<IActionResult> Put(OperationData product)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                await _service.UpdateOperationData(product);
                return Ok(new { Message = "Product Status updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
