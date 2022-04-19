using MediatR;
using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Commands.GameCommands
{
    public class BaseGetAllByExpression
    {

        public class Query<T> : IRequest<List<T>>
        {

           private  Func<T, bool> _expression;

            public Query(Func<T,bool> expression)
            {
                _expression = expression;
            }

            public class QueryHandler : IRequestHandler<Query<T>, List<T>>
            {
                private IAsyncRepository<T> _repository;

                public QueryHandler(IAsyncRepository<T> repository)
                {
                    _repository = repository;
                }
                public async Task<List<T>> Handle(Query<T> request, CancellationToken cancellationToken)
                {
                    return await _repository.GetByExpressionAsync(request._expression);
                }
            }
        }
    }
}
