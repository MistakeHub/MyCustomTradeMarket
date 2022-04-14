using MediatR;
using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Commands.GameCommands
{
    public class BaseUpdate
    {
        public class Command<T> : IRequest<bool>
        {
            private T _entity;

            public Command(T property)
            {
                _entity = property;

            }

            public class CommandHandler : IRequestHandler<Command<T>, bool>
            {


                public CommandHandler(IMediator mediator, IAsyncRepository<T> repository)
                {
                    _repository = repository;
                    _mediator = mediator;
                }

                private IAsyncRepository<T> _repository;
                private IMediator _mediator;
                public async Task<bool> Handle(Command<T> request, CancellationToken cancellationToken)
                {

                    return await _repository.Update(request._entity);
                }
            }
        }

    }
}
