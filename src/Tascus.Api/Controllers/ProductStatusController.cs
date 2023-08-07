using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Tascus.Service.Interfaces;
using Tascus.Service.Services;

namespace Tascus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductStatusController : BaseApiController
    {
        private readonly IOperationDataService _service;

        public ProductStatusController(IOperationDataService service, IMapper mapper): base(mapper) 
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Production_Payload payload)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var data = await _service.GetOperationData(payload);
                return Ok(_mapper.Map<List<OperationDto>>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public async Task<IActionResult> Put(Operation_Payload payload)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var product = _mapper.Map<OperationData>( payload);
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
