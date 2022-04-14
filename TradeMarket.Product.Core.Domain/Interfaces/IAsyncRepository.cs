using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMarket.Product.Core.Domain.Interfaces
{
    public interface IAsyncRepository<T>
    {

        public Task<T> GetById(int id);

      
        public Task<List<T>> GetAll();
        public Task<bool> Remove(int Id);
        public Task<List<T>> GetByExpression(Func<T, bool> expression);
        public Task<bool> Add(T entity);
        public Task<bool> RemoveRange(int[] entities);
        public Task<bool> Update(T entity);


    }
}
