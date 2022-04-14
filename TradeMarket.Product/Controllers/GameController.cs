using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TradeMarket.Product.Commands.GameCommands;

using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Controllers
{
    [Route("api/Product/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        private IMediator _mediator;

        public GameController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<Game> Get(int id)
        {
            return await _mediator.Send(new BaseGet.Query<Game>(id));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<List<Game>> GetAll()
        {

            return await _mediator.Send(new BaseGetAll.Query<Game>());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Allbyexpression")]
        public async Task<List<Game>> GetAllByExpression(string Game)
        {
            return await _mediator.Send(new BaseGetAllByExpression.Query<Game>((n) => n.Game1 == Game));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Add")]
        public async Task<bool> Add(Game game)
        {
            return await _mediator.Send(new BaseAdd.Command<Game>(game));
        }

        [HttpDelete("Remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<bool> Remove(int Id)
        {
            return await _mediator.Send(new BaseRemove.Command<Game>(Id));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("RemoveRange")]
        public async Task<bool> RemoveRange(int[] games)
        {
            return await _mediator.Send(new BaseRemoveRange.Command<Game>(games));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Update")]
        public async Task<bool> Update(Game game)
        {
            return await _mediator.Send(new BaseUpdate.Command<Game>(game));

        }




    }
}
