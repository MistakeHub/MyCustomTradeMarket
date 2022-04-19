using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMarket.Product.Core.Domain.Interfaces
{
    public interface IAsyncRepository<T>
    {

        public Task<T> GetByIdAsync(int id);

      
        public Task<List<T>> GetAllAsync();
        public Task<bool> RemoveAsync(int Id);
        public Task<List<T>> GetByExpressionAsync(Func<T, bool> expression);
        public Task<bool> AddAsync(T entity);
        public Task<bool> RemoveRangeAsync(int[] entities);
        public Task<bool> UpdateAsync(T entity);


    }
}
