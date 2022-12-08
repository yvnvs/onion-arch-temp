using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onion.Application.Dto;
using onion.Application.Features.Commands.CreateProduct;
using onion.Application.Features.Queries.GetAllProducts;
using onion.Application.Features.Queries.GetProductById;
using onion.Application.Interfaces.Repository;
using onion.Application.Wrappers;

namespace onion.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IMediator mediator { get; }
        public ProductController(IMediator mediator)
        {
            
            this.mediator = mediator;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();

            return Ok(await mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery() {Id = id};

            return Ok(await mediator.Send(query));
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
