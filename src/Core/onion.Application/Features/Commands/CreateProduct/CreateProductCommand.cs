using MediatR;
using onion.Application.Interfaces.Repository;
using onion.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace onion.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            IProductRepository productRepository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository;
                _mapper = mapper;
            }

            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<Domain.Entities.Product>(request);
                await productRepository.AddAsync(product);

                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
