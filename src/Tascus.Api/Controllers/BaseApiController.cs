using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Tascus.Api.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseApiController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
