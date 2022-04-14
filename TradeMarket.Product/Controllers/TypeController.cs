using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeMarket.Product.Commands.GameCommands;

using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Controllers
{
    [Route("api/Product/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private IMediator _mediator;

        public TypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<Typeofitem> Get(int id)
        {
            return await _mediator.Send(new BaseGet.Query<Typeofitem>(id));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<List<Typeofitem>> GetAll()
        {

            return await _mediator.Send(new BaseGetAll.Query<Typeofitem>());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Allbyexpression")]
        public async Task<List<Typeofitem>> GetAllByExpression(string Type)
        {
            return await _mediator.Send(new BaseGetAllByExpression.Query<Typeofitem>((n) => n.Type1 == Type));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Add")]
        public async Task<bool> Add(Typeofitem Type)
        {
            return await _mediator.Send(new BaseAdd.Command<Typeofitem>(Type));
        }

        [HttpDelete("Remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<bool> Remove(int Id)
        {
            return await _mediator.Send(new BaseRemove.Command<Typeofitem>(Id));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("RemoveRange")]
        public async Task<bool> RemoveRange(int[] Types)
        {
            return await _mediator.Send(new BaseRemoveRange.Command<Typeofitem>(Types));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Update")]
        public async Task<bool> Update(Typeofitem Type)
        {
            return await _mediator.Send(new BaseUpdate.Command<Typeofitem>(Type));

        }
    }
}
