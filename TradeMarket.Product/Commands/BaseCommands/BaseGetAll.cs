using MediatR;
using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Commands.GameCommands
{
    public class BaseGetAll
    {

        public class Query<T> : IRequest<List<T>>
        {
         

            
            public class QueryHandler : IRequestHandler<Query<T>, List<T>>
            {


                public QueryHandler( IAsyncRepository<T> repository)
                {
                    _repository = repository;
                   
                }

                private IAsyncRepository<T> _repository;
            
                public async Task<List<T>> Handle(Query<T> request, CancellationToken cancellationToken)
                {
                    return await _repository.GetAll();
                }
            }
        }
    }
}
