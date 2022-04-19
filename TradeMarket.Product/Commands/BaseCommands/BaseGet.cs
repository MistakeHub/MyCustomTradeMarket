using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMarket.Product.Core.Domain.Interfaces;
using TradeMarket.Product.sakila;

namespace TradeMarket.Product.Commands.GameCommands
{
    public class BaseGet
    {

        public class Query<T> : IRequest<T>
        {

            private int _id;

            public Query(int id)
            {
                _id = id;
            }

            public class QueryHandler : IRequestHandler<Query<T>, T>
            {

                public QueryHandler(IAsyncRepository<T> repository)
                {
                    _repository = repository;
                }
                private IAsyncRepository<T> _repository;
                public async Task<T> Handle(Query<T> request, CancellationToken cancellationToken)
                {
                    return await _repository.GetByIdAsync(request._id);
                }
            }

        }

    }
}
