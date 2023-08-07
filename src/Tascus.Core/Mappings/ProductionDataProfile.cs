using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tascus.Core.Dtos;
using Tascus.Core.Model;

namespace Tascus.Core.Mappings
{
    public class ProductionDataProfile: Profile
    {
        public ProductionDataProfile()
        {
            CreateMap<ProductionData, ProductionDto>().ReverseMap();
        }
    }
}
