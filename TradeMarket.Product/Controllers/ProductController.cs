using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using TradeMarket.Product.Commands.GameCommands;

using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<Productitem> Get(int id)
        {
            return await _mediator.Send(new BaseGet.Query<Productitem>(id));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<List<Productitem>> GetAll()
        {

            return await _mediator.Send(new BaseGetAll.Query<Productitem>());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Allbyexpression")]
        public async Task<List<Productitem>> GetAllByExpression(string Productitem)
        {
            return await _mediator.Send(new BaseGetAllByExpression.Query<Productitem>((n) => n.IditemNavigation.Name == Productitem));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Add")]
        public async Task<bool> Add(Productitem Productitem)
        {
            return await _mediator.Send(new BaseAdd.Command<Productitem>(Productitem));
        }

        [HttpDelete("Remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<bool> Remove(int Id)
        {
            return await _mediator.Send(new BaseRemove.Command<Productitem>(Id));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("RemoveRange")]
        public async Task<bool> RemoveRange(int[] Productitems)
        {
            return await _mediator.Send(new BaseRemoveRange.Command<Productitem>(Productitems));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Update")]
        public async Task<bool> Update(Productitem Productitem)
        {
            return await _mediator.Send(new BaseUpdate.Command<Productitem>(Productitem));

        }


    }
}
