using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using TradeMarket.Product.Commands.GameCommands;

using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.sakila;
using TradeMarket.Product.ViewModels;

namespace TradeMarket.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IMediator _mediator;
        private IMapper _mapper;

        public ProductController(IMapper mapper,IMediator mediator)
        {
            _mapper = mapper; 
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ProductViewModel> Get(int id)
        {
            var entity= await _mediator.Send(new BaseGet.Query<Productitem>(id));
            return _mapper.Map<ProductViewModel>(entity);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<List<ProductViewModel>> GetAll()
        {
            var entities=await _mediator.Send(new BaseGetAll.Query<Productitem>());
            return _mapper.Map<List<ProductViewModel>>(entities);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Allbyexpression")]
        public async Task<List<ProductViewModel>> GetAllByExpression([FromBody] string productitem)
        {
            var entities = await _mediator.Send(new BaseGetAllByExpression.Query<Productitem>((n) => n.IditemNavigation.Name == productitem)); ;
            return _mapper.Map<List<ProductViewModel>>(entities);

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Add")]
        public async Task<bool> Add([FromBody] Productitem productitem)
        {
            return await _mediator.Send(new BaseAdd.Command<Productitem>(productitem));
        }

        [HttpDelete("Remove/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<bool> Remove(int id)
        {
            return await _mediator.Send(new BaseRemove.Command<Productitem>(id));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("RemoveRange")]
        public async Task<bool> RemoveRange([FromBody] int[] productitems)
        {
            return await _mediator.Send(new BaseRemoveRange.Command<Productitem>(productitems));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("Update")]
        public async Task<bool> Update([FromBody] Productitem productitem)
        {
            return await _mediator.Send(new BaseUpdate.Command<Productitem>(productitem));

        }


    }
}
