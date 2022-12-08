using AutoMapper;
using MediatR;
using onion.Application.Dto;
using onion.Application.Interfaces.Repository;
using onion.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onion.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery: IRequest<ServiceResponse<List<ProductViewDto>>>
    {


        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, ServiceResponse<List<ProductViewDto>>>
        {
            private readonly IProductRepository productRepository;
            private readonly IMapper mapper;

            public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                this.mapper = mapper;
            }


            public async Task<ServiceResponse<List<ProductViewDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {

                var produtcs = await productRepository.GetAllAsync();

                var viewModel = mapper.Map<List<ProductViewDto>>(produtcs);


                return new ServiceResponse<List<ProductViewDto>>(viewModel);
            }
        }
    }
}
