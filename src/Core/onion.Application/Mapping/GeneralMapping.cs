using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onion.Application.Features.Commands.CreateProduct;
using onion.Application.Features.Queries.GetProductById;

namespace onion.Application.Mapping
{
    public  class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product, Dto.ProductViewDto>().ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductCommand>().ReverseMap();
            CreateMap<Domain.Entities.Product, GetProductByIdViewModel>().ReverseMap();
        }
    }
}
