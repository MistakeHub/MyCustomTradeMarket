using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMarket.Product.Core.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        public T GetById(int id);

        public List<T> GetAll();

        public bool Remove(int Id);

        public bool RemoveRange(int[] entities);
        public List<T> GetByExpression(Func<T, bool> expression);

        public bool Add(T entity);

        public bool Update(T entity);

        


    }
}
