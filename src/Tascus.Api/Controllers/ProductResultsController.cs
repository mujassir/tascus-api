using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tascus.Core.Dtos;
using Tascus.Core.Model;
using Tascus.Service.Interfaces;

namespace Tascus.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductResultsController : BaseApiController
    {
        private readonly IProductionDataServices _service;

        public ProductResultsController(IProductionDataServices service, IMapper mapper) : base(mapper)
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

                var data = await _service.GetProductionData(payload);
                return Ok(_mapper.Map<List<ProductionDto>>(data));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductionDto payload)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var product = _mapper.Map<ProductionData>(payload);
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
