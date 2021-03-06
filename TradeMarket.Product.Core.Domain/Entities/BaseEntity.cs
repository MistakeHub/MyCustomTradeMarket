using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMarket.Product.Core.Domain.Entities
{
   public abstract class BaseEntity<TKey>
    {

        public TKey Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}
