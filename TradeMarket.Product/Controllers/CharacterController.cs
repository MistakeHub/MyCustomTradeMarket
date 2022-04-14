using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeMarket.Product.Commands.GameCommands;

using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Controllers
{
    [Route("api/Product/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {

        private IMediator _mediator;

        public CharacterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<Character> Get(int id)
        {
            return await _mediator.Send(new BaseGet.Query<Character>(id));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<List<Character>> GetAll()
        {

            return await _mediator.Send(new BaseGetAll.Query<Character>());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Allbyexpression")]
        public async Task<List<Character>> GetAllByExpression(string Character)
        {
            return await _mediator.Send(new BaseGetAllByExpression.Query<Character>((n) => n.Character1 == Character));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Add")]
        public async Task<bool> Add(Character Character)
        {
            return await _mediator.Send(new BaseAdd.Command<Character>(Character));
        }

        [HttpDelete("Remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<bool> Remove(int Id)
        {
            return await _mediator.Send(new BaseRemove.Command<Character>(Id));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("RemoveRange")]
        public async Task<bool> RemoveRange(int[] Characters)
        {
            return await _mediator.Send(new BaseRemoveRange.Command<Character>(Characters));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Update")]
        public async Task<bool> Update(Character Character)
        {
            return await _mediator.Send(new BaseUpdate.Command<Character>(Character));

        }
    }
}
