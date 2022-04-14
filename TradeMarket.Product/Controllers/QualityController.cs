using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradeMarket.Product.Commands.GameCommands;

using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Controllers
{
    [Route("api/Product/[controller]")]
    [ApiController]
    public class QualityController : ControllerBase
    {

        private IMediator _mediator;

        public QualityController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<Quality> Get(int id)
        {
            return await _mediator.Send(new BaseGet.Query<Quality>(id));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<List<Quality>> GetAll()
        {

            return await _mediator.Send(new BaseGetAll.Query<Quality>());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("Allbyexpression")]
        public async Task<List<Quality>> GetAllByExpression(string Quality)
        {
            return await _mediator.Send(new BaseGetAllByExpression.Query<Quality>((n) => n.Quality1 == Quality));

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("Add")]
        public async Task<bool> Add(Quality Quality)
        {
            return await _mediator.Send(new BaseAdd.Command<Quality>(Quality));
        }

        [HttpDelete("Remove")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<bool> Remove(int Id)
        {
            return await _mediator.Send(new BaseRemove.Command<Quality>(Id));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("RemoveRange")]
        public async Task<bool> RemoveRange(int[] Qualities)
        {
            return await _mediator.Send(new BaseRemoveRange.Command<Quality>(Qualities));

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status412PreconditionFailed)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Update")]
        public async Task<bool> Update(Quality Quality)
        {
            return await _mediator.Send(new BaseUpdate.Command<Quality>(Quality));

        }
    }
}
