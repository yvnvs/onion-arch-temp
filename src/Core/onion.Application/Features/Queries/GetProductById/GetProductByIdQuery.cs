using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using onion.Application.Dto;
using onion.Application.Interfaces.Repository;
using onion.Application.Wrappers;

namespace onion.Application.Features.Queries.GetProductById
{
    public  class GetProductByIdQuery : IRequest<ServiceResponse<GetProductByIdViewModel>>
    {
        public Guid Id { get; set; }

        public  class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ServiceResponse<GetProductByIdViewModel>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;

            public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
            }


            public async Task<ServiceResponse<GetProductByIdViewModel>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                var viewModel = _mapper.Map<GetProductByIdViewModel>(product);

                return new ServiceResponse<GetProductByIdViewModel>(viewModel);
            }
        }
    }
}
