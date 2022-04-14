using System;
using System.Collections.Generic;
using TradeMarket.Product.Core.Domain.Entities;

namespace TradeMarket.Product.sakila
{
    public partial class Quality : BaseEntity<int>
    {
        public Quality()
        {
            Items = new HashSet<Item>();
        }

      
        public string Quality1 { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public override string ToString()
        {
            return $"Quality: Id:{this.Id}| Quality:{this.Quality1}";
        }
    }
}
